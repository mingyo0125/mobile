using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    //Bezier 
    public static void AttractPosition(this MonoBehaviour monoBehaviour,
                                       Transform obj,
                                       Vector2 startPos, Transform endPos,
                                       float duration, float spreadPower,
                                       params Action[] endActions)
    {
        if(monoBehaviour.isActiveAndEnabled)
        {
            monoBehaviour.StartCoroutine(AttractCorou(obj, startPos, endPos, duration, spreadPower, endActions));
        }
    }

    private static IEnumerator AttractCorou(Transform obj,
                                     Vector2 startPos, Transform endPos,
                                     float duration, float spreadPower,
                                     params Action[] endActions)
    {
        Vector2 cetnerVec = startPos + UnityEngine.Random.insideUnitCircle * spreadPower;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            Vector2 v1 = Vector2.Lerp(startPos, cetnerVec, t);
            Vector2 v2 = Vector2.Lerp(cetnerVec, endPos.position, t);

            obj.position = Vector2.Lerp(v1, v2, t);

            yield return null;
        }

        obj.position = endPos.position;

        foreach (Action action in endActions)
        {
            action?.Invoke();
        }
    }
}
