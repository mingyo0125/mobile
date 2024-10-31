using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startXPos;
    private float length;

    [SerializeField]
    private float parallaxSpeed;

    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
        startXPos = transform.position.x;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void LateUpdate()
    {
        float distance = _cam.transform.position.x * parallaxSpeed;
        float movement = _cam.transform.position.x * (1f - parallaxSpeed);

        transform.position = new Vector3(startXPos + distance, transform.position.y, transform.position.z);

        if (_cam.transform.position.x > startXPos + length)
        {
            startXPos += length;
        }
        else if (_cam.transform.position.x < startXPos - length)
        {
            startXPos -= length;
        }
    }
}
