using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryButtonContainer : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.width / (transform.childCount + 1), 200);
    }
}
