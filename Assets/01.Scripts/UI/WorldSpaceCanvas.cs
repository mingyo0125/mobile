using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCanvas : MonoBehaviour
{
    private Quaternion initialRotation;

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = initialRotation;
    }
}
