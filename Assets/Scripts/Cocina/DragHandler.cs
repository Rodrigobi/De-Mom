using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public static GameObject itemDragging;

    Vector3 startPosition;
    Transform startParent;
    Transform dragParent;

    private void Start()
    {
        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemDragging = gameObject;

        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(dragParent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemDragging = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent == dragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Ensure that the item is on top when clicked
        transform.SetAsLastSibling();
    }
}
