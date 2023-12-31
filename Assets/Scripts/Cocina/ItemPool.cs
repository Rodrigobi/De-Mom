using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPool : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragHandler dragHandler = eventData.pointerDrag.GetComponent<DragHandler>();
            if (dragHandler != null)
            {
                DropSlot dropSlot = GetComponentInParent<DropSlot>();
                if (dropSlot != null && dropSlot.CanAcceptItems())
                {
                    dragHandler.transform.SetParent(transform);
                    dragHandler.transform.position = transform.position;
                    dragHandler.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                    dropSlot.GetComponent<DropSlot>().ItemDropped(); // Call the ItemDropped method in the DropSlot script
                }
            }
        }
    }
}
