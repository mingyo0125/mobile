using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttackState : EntityAttackState<PlayerStateType, Player>
{
    public PlayerAttackState(Player player, EntityStateMachine<PlayerStateType, Player> entityStateMachine):
                             base(player, entityStateMachine)
    {

    }

	public override void ChangeIdleState()
	{
		_stateMachine.ChangeState(PlayerStateType.Idle);
	}

    protected override void TakeDamage()
    {
        Collider2D[] inRangeColliders = GetInRange(_owner.EntityStat.AttackRange).Item2;
        List<float> inRangeEntitiesAngle = new List<float>();
        Dictionary<float , Collider2D> inRangeEntitesDic = new Dictionary<float , Collider2D>();

        foreach(Collider2D collider in inRangeColliders)
        {
            float angle = GetAngle(_owner.EquipWeapon.transform.position, collider.transform.position);
            inRangeEntitiesAngle.Add(angle);
            inRangeEntitesDic.Add(angle, collider);
        }

        inRangeEntitiesAngle.Sort();

        _owner.StartCoroutine(TakeDamageCorou(inRangeEntitiesAngle, inRangeEntitesDic));
    }

    public float GetAngle(Vector3 startVec, Vector3 endVec)
    {
        Vector3 v = endVec - startVec;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }

    private IEnumerator TakeDamageCorou(List<float>sortedAngles, Dictionary<float, Collider2D> inRangeEntitesDic)
    {
        foreach (float angle in sortedAngles)
        {
            if (inRangeEntitesDic[angle].TryGetComponent(out IDamageable component))
            {
                var calcuDamage = _owner.GetDamage();
                bool isCritical = calcuDamage.Item1;
                float damage = calcuDamage.Item2;

                component.TakedDamage(isCritical, damage);
            }
            else
            {
                Debug.Log($"{inRangeEntitesDic[angle]} not have IDamageable");
            }
            yield return new WaitForSeconds(0.1f); // 나중에 공속
        }
    }
}
