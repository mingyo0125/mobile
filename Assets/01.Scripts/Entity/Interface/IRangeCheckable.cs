using UnityEngine;

public interface IRangeCheckable
{
    public (bool, Collider2D[]) GetInRange(float checkRange);
    public Vector2 GetShortestTargetPos(Collider2D[] inRangeTargets);
}
