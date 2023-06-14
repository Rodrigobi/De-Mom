using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour
{
    private int itemCount;

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
}
