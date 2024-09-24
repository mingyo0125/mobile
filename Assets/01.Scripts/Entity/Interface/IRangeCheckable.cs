using UnityEngine;

public interface IRangeCheckable
{
    public float CheckRange {  get; set; }
    public LayerMask CheckLayer { get; set; }

    public (bool, Collider2D[]) GetInRange();
}
