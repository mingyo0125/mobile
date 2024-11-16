using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridlayoutController : MonoBehaviour
{
    [SerializeField]
    private float xValue, yValue;

    [SerializeField]
    private bool isfullHorizontal, isfullVertical;

    private void Start()
    {
        int iisfullHorizontal = isfullHorizontal ? 1 : 0;
        int iisfullVertical = isfullVertical ? 1 : 0;

        Vector2 cellSize = new Vector2(xValue + Screen.width * iisfullHorizontal,
                                       yValue + Screen.height * iisfullVertical);

        GetComponent<GridLayoutGroup>().cellSize = cellSize;
    }
}
