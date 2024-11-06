using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackEffect : PoolableMono
{
    public void AnimationEndEvent()
    {
        PoolManager.Instance.DestroyObject(this);
    }
}
