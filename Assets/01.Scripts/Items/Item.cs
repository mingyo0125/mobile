using DG.Tweening;
using System.Collections;
using UnityEngine;

public abstract class Item : PoolableMono
{
    public override void Initialize()
    {
        base.Initialize();

        CoroutineUtil.CallWaitForSeconds(1f, () =>
        {
            this.AttractPosition(transform, transform.position, GameManager.Instance.GetPlayerTrm(), 0.7f, 1.5f);
        });
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            GetItem(player);
            PoolManager.Instance.DestroyObject(this);
        }
    }

    protected abstract void GetItem(Player player);
}
