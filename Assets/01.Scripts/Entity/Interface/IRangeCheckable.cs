using UnityEngine;

public interface IRangeCheckable
{
    public float CheckRangeDistance {  get; set; }
    public LayerMask CheckLayer { get; set; }

    public (bool, Collider2D[]) GetInRange(float checkRange);
}
