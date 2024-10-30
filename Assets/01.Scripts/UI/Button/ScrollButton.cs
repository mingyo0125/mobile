using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,
                            IPointerDownHandler, IPointerUpHandler
{
    // 열심히 만들었지만 사용하지 않을 것이니 지우거라

    private float slidingHeight;

    [SerializeField]
    private RectTransform _slidingArea;

    private bool isDragging;

    [SerializeField]
    private Image _scrollHandle;

    [SerializeField]
    private Color _pressedColor;

    [SerializeField]
    private Image _arrowImage;

    private void Awake()
    {
        slidingHeight = _slidingArea.rect.height;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            float dragYPos = Mathf.Clamp(eventData.position.y, 0, slidingHeight);
            ((RectTransform)transform.parent).anchoredPosition = new Vector3(0, dragYPos, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragging) { return; }

        isDragging = false;

        RectTransform rectransform = (RectTransform)transform.parent;

        bool canOnUI = rectransform.anchoredPosition.y > slidingHeight * 0.4f;
        if (!canOnUI)
        {
            rectransform.anchoredPosition = new Vector2(0, 0);

            _arrowImage.transform.rotation = Quaternion.Euler(0, 0, -90);
            return;
        }

        _arrowImage.transform.rotation = Quaternion.Euler(0, 0, 90);
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