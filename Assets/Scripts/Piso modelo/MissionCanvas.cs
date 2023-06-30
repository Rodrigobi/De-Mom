using UnityEngine;
using UnityEngine.UI;

public class MissionCanvas : MonoBehaviour
{
    public Text npcText;

    private MissionManager missionManager;

    private void Start()
    {
        // Find the MissionManager in the scene
        missionManager = FindObjectOfType<MissionManager>();
        
        // Update the NPC text initially
        UpdateNPCText();
    }

    private void UpdateNPCText()
    {
        // Get the current mission progress
        int talkedToNPCs = PlayerPrefs.GetInt("MissionProgress");
        
        // Update the NPC text with the current progress
        npcText.text = "NPCs talked to: " + talkedToNPCs + "/" + missionManager.totalNPCs;
    }
    
    // Call this method whenever the mission progress is updated
    public void MissionProgressUpdated()
    {
        UpdateNPCText();
    }
}
