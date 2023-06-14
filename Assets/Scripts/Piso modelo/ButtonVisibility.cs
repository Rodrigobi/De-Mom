using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVisibility : MonoBehaviour
{
    public string npcTag = "CanDeliverObject";
    public float detectionRadius = 3f;
    public Button interactionButton;

    private GameObject nearestNPC;
    private bool isNearNPC;

    void Update()
    {
        // Find all NPCs with the specified tag
        GameObject[] npcs = GameObject.FindGameObjectsWithTag(npcTag);

        // Find the nearest NPC within the detection radius
        nearestNPC = FindNearestNPC(npcs);

        // Check if the player is near an NPC
        isNearNPC = nearestNPC != null && Vector3.Distance(transform.position, nearestNPC.transform.position) <= detectionRadius;

        // Show/hide the interaction button based on proximity to NPC
        if (interactionButton != null)
        {
            interactionButton.gameObject.SetActive(isNearNPC);
        }
    }

    GameObject FindNearestNPC(GameObject[] npcs)
    {
        GameObject nearest = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(transform.position, npc.transform.position);
            if (distance < nearestDistance)
            {
                nearest = npc;
                nearestDistance = distance;
            }
        }

        return nearest;
    }
}
