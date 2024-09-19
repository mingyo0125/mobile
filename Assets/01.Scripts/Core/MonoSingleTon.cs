using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<T>();

                if(instance == null)
                {
                    GameObject singleTonObj = new GameObject();
                    singleTonObj.transform.SetParent(GameObject.Find("Managers").transform);
                    singleTonObj.name = typeof(T).Name;
                    singleTonObj.AddComponent<T>();
                }
            }

            return instance;
        }
    }
}
