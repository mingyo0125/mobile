using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour, IDragHandler, IBeginDragHandler , IEndDragHandler
{
    private float slidingHeight;

    private RectTransform _slidingArea;

    private bool isDragging;

    private void Awake()
    {
        _slidingArea = transform.parent.GetComponent<RectTransform>();

        slidingHeight = _slidingArea.rect.height;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            float dragYPos = Mathf.Clamp(eventData.position.y, 0, slidingHeight);
            ((RectTransform)transform).anchoredPosition = new Vector3(0, dragYPos, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        RectTransform rectransform = (RectTransform)transform;

        if (rectransform.anchoredPosition.y > slidingHeight * 0.5f)
        {
            rectransform.anchoredPosition = new Vector2(0, slidingHeight);
        }
        else
        {
            rectransform.anchoredPosition = new Vector2(0, 0);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter != gameObject)
        {
            return;
        }

        isDragging = true;
    }
}