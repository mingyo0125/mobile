using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : EntityAnimator
{
    private Queue<string> _attackAnimationTriggerQueue = new Queue<string>();
    private Dictionary<string, Action> _attackAnimationEvents =
            new Dictionary<string, Action>();

    public void QueueSkillAnimationTrigger(string key, float speed = 1, Action action = null)
    {
        _attackAnimationTriggerQueue.Enqueue(key);

        if (action != null &&
           !_attackAnimationEvents.ContainsKey(key))
        {
            _attackAnimationEvents.Add(key, action);
        }

        AnimatorCompo.SetFloat("AttackSpeed", 1f / speed);

        if (!isAnimationPlaying)
        {
            PlayAttackAnimation();
        }
    }

    public override void EndAttackEventTrigger()
    {
        base.EndAttackEventTrigger();

        if (_attackAnimationTriggerQueue.Count > 0) // 큐에 값이 있다면
        {
            PlayAttackAnimation(); // 다음 애니메이션 실행
        }
        else
        {
            EndAttack();
        }
    }

    protected override void EndAttack()
    {
        base.EndAttack();

        Debug.Log("EndAttack");
        _owner.GetEntity<PlayerStateType, Player>().StateMachine.ChangeState(PlayerStateType.Idle);
    }

    protected override void OnDisable()
    {
        _attackAnimationEvents.Clear();
        _attackAnimationTriggerQueue.Clear();

        base.OnDisable();
    }

    public override void AttackEventTrigger()
    {
        string nextAniamtionName = _attackAnimationTriggerQueue.Dequeue();
        if (_attackAnimationEvents.TryGetValue(nextAniamtionName, out Action action))
        {
            action?.Invoke();
            _attackAnimationEvents.Remove(nextAniamtionName);
        }
    }
}
