using System;
using System.Collections;
using UnityEngine;

public static class CoroutineUtil
{
    private static GameObject _coroutineObj;
    private static MonoExecutor _coroutineExecutor;

    static CoroutineUtil()
    {
        CreateCoroutineExecutor();
    }

    private static void CreateCoroutineExecutor()
    {
        if (_coroutineObj != null)
        {
            UnityEngine.Object.Destroy(_coroutineObj);
        }

        _coroutineObj = new GameObject("CoroutineObj");
        UnityEngine.Object.DontDestroyOnLoad(_coroutineObj);
        _coroutineExecutor = _coroutineObj.AddComponent<MonoExecutor>();
    }

    private static void EnsureCoroutineExecutor()
    {
        if (_coroutineExecutor == null)
        {
            CreateCoroutineExecutor();
        }
    }

    public static void CallWaitForOneFrame(Action action)
    {
        EnsureCoroutineExecutor();
        _coroutineExecutor.StartCoroutine(DoCallWaitForOneFrame(action));
    }

    public static void CallWaitForSeconds(float seconds, Action afterAction)
    {
        EnsureCoroutineExecutor();
        _coroutineExecutor.StartCoroutine(DoCallWaitForSeconds(seconds, afterAction));
    }

    private static IEnumerator DoCallWaitForOneFrame(Action action)
    {
        yield return null;
        action?.Invoke();
    }

    private static IEnumerator DoCallWaitForSeconds(float seconds, Action afterAction)
    {
        yield return new WaitForSeconds(seconds);
        afterAction?.Invoke();
    }

    private class MonoExecutor : MonoBehaviour { }
}
