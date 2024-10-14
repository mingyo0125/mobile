using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollButton : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("a");
    }

}
