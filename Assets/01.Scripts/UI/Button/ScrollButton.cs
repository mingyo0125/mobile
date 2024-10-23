using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,
                            IPointerDownHandler, IPointerUpHandler
{
    private float slidingHeight;

    private RectTransform _slidingArea;

    private bool isDragging;

    private Image _scrollHandle;

    [SerializeField]
    private Color _pressedColor;

    private void Awake()
    {
        _slidingArea = transform.parent.GetComponent<RectTransform>();
        _scrollHandle = GetComponent<Image>();

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
        if (!isDragging) { return; }

        isDragging = false;

        RectTransform rectransform = (RectTransform)transform;

        bool canOnUI = rectransform.anchoredPosition.y > slidingHeight * 0.4f;
        if (!canOnUI)
        {
            rectransform.anchoredPosition = new Vector2(0, 0);
            return;
        }
        rectransform.anchoredPosition = new Vector2(0, slidingHeight);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter != gameObject)
        {
            return;
        }

        _scrollHandle.color = _pressedColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _scrollHandle.color = Color.white;
    }
}