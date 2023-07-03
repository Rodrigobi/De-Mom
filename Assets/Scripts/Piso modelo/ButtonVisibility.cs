using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVisibility : MonoBehaviour
{
    public List<string> npcTags = new List<string> { "NPC1", "NPC2", "NPC3", "NPC4", "NPC5", "NPC6" };
    public float detectionRadius = 3f;
    public Button interactionButton;

    private GameObject nearestNPC;
    private bool isNearNPC;

    private MissionManager missionManager; // Reference to the MissionManager script

    private void Start()
    {
        missionManager = FindObjectOfType<MissionManager>(); // Find the MissionManager script in the scene
    }

    void Update()
    {
        // Find all NPCs with the specified tags
        List<GameObject> npcs = new List<GameObject>();
        foreach (string tag in npcTags)
        {
            GameObject[] taggedNPCs = GameObject.FindGameObjectsWithTag(tag);
            npcs.AddRange(taggedNPCs);
        }

        // Find the nearest NPC within the detection radius
        nearestNPC = FindNearestNPC(npcs.ToArray());

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

    public void TalkToNPC()
    {
        if (isNearNPC && nearestNPC != null)
        {
            string npcTag = nearestNPC.tag;
            if (npcTags.Contains(npcTag))
            {
                // Call the CountNPC method in the MissionManager script
                missionManager.UpdateMissionProgress(npcTag);
                // Add your dialogue logic here
            }
        }
    }
}
