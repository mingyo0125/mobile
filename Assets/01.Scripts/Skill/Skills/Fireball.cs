using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : BaseSkill
{
    public override void Execute(Player user, Vector2 pos)
    { 
        Debug.Log(SkillInfo.Description);
        PlayEffect(pos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isEnemy = collision.TryGetComponent(out IDamageable damageable) && damageable is Enemy;

        if (!isEnemy) { return; }

        damageable.TakedDamage(GameManager.Instance.GetPlayer().GetTakeDamageInfo(true));

        _effect.StopImmediately();
        _effect.AnimationEndEvent();
    }
}
