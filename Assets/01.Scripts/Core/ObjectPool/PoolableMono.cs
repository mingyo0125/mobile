using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableMono : MonoBehaviour
{
    public virtual void Initialize() { }
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}
