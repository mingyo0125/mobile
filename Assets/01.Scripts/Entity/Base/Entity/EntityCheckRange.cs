using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Entity<T, G> : IRangeCheckable
{
    public float CheckRange { get; set; }

    [field: SerializeField]
    public LayerMask CheckLayer { get; set; }

    private void InitializeRangeCheckable()
    {
        CheckRange = _entityStatSO.EntityStat.CheckAttackRange;
    }

    public (bool, Collider2D[]) GetInRange()
    {
        Collider2D[] inRangeColliders = Physics2D.OverlapCircleAll(transform.position, CheckRange, CheckLayer);
        return (inRangeColliders.Length > 0, inRangeColliders);
    }
}
