using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract partial class Entity<T, G> : IRangeCheckable
{
    public float CheckRangeDistance { get; set; }

    [field: SerializeField]
    public LayerMask CheckLayer { get; set; }


    [Header("CheckRange")]
    [SerializeField]
    private bool isDrawRangeGizmo = false;
    [SerializeField]
    private Color _gizmoColor;

    private void RangeCheckableAwake()
    {
        CheckRangeDistance = _entityStatSO.EntityStat.CheckAttackRange;
    }

    public (bool, Collider2D[]) GetInRange(float checkRange)
    {
        Collider2D[] inRangeColliders = Physics2D.OverlapCircleAll(transform.position, checkRange, CheckLayer);
        return (inRangeColliders.Length > 0, inRangeColliders);
    }

    private void OnDrawGizmos()
    {
        if (isDrawRangeGizmo)
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawWireSphere(transform.position, CheckRangeDistance);
        }
    }

	public Vector2 GetShortestTargetPos(Collider2D[] inRangeTargets)
	{
		Collider2D shortestCollider = inRangeTargets.FirstOrDefault();

		foreach (Collider2D collider in inRangeTargets)
		{
			bool isShortestDistance = Vector3.Distance(transform.position, collider.transform.position) <
									  Vector3.Distance(transform.position, shortestCollider.transform.position);

			if (isShortestDistance)
			{
				shortestCollider = collider;
			}
		}

        return shortestCollider.transform.position;
	}
}
