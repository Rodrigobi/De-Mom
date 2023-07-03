using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private int itemCount;
    private bool hasItem; // Variable to track if the slot has an item

    public void OnDrop(PointerEventData eventData)
    {
        if (!hasItem)
        {
            if (eventData.pointerDrag != null)
            {
                DragHandler dragHandler = eventData.pointerDrag.GetComponent<DragHandler>();
                if (dragHandler != null)
                {
                    dragHandler.transform.SetParent(transform);
                    dragHandler.transform.position = transform.position;
                    dragHandler.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                    hasItem = true; // Set the flag to indicate that the slot has an item
                    ItemDropped();
                }
            }
        }
    }

    public void ItemDropped()
    {
        itemCount++;

        if (itemCount >= 4)
        {
            // Do something when four items are inside the drop slot
            Debug.Log("Four items are inside the drop slot!");

            // Reset the counter and clear the drop slot
            itemCount = 0;
            ClearDropSlot();
        }
    }

    private void ClearDropSlot()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public bool CanAcceptItems()
    {
        return itemCount < 4;
    }

    public bool HasItem()
    {
        return hasItem;
    }
}
