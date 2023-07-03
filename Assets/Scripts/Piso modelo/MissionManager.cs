using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    // Singleton instance
    private static MissionManager instance;

    // PlayerPrefs key to store mission progress
    private string missionProgressKey = "MissionProgress";

    // Number of NPCs to talk to
    public int totalNPCs = 6;

    // Current mission progress
    private int missionProgress;

    // Getter for the singleton instance
    public static MissionManager Instance { get { return instance; } }

    private void Awake()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            // Destroy this instance if another one already exists
            Destroy(gameObject);
            return;
        }

        // Set the instance to this object
        instance = this;

        // Keep the MissionManager across scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Check if the mission progress is already stored
        if (PlayerPrefs.HasKey(missionProgressKey))
        {
            // Load the mission progress
            missionProgress = PlayerPrefs.GetInt(missionProgressKey);
        }
        else
        {
            // Initialize the mission progress and save it
            missionProgress = 0;
            SaveMissionProgress();
        }
    }

    // Method to update the mission progress based on the current scene
    public void UpdateMissionProgress(string npcTag)
    {
        // Check if the NPC tag is part of the mission
        if (IsMissionNPC(npcTag))
        {
            // Extract the NPC number from the tag
            int npcNumber = int.Parse(npcTag.Substring(3));

            // Check if the NPC has not been talked to yet
            if ((missionProgress & (1 << npcNumber)) == 0)
            {
                // Mark the NPC as talked to
                missionProgress |= (1 << npcNumber);

                // Save the updated mission progress
                SaveMissionProgress();

                // Check if the mission is completed
                if (IsMissionCompleted())
                {
                    // Mission completed logic
                }
            }
        }
    }

    // Method to check if the NPC tag is part of the mission
    private bool IsMissionNPC(string npcTag)
    {
        return npcTag.StartsWith("NPC");
    }

    // Method to check if the mission is completed
    public bool IsMissionCompleted()
    {
        return missionProgress == (1 << totalNPCs) - 1;
    }

    // Method to save the mission progress
    private void SaveMissionProgress()
    {
        PlayerPrefs.SetInt(missionProgressKey, missionProgress);
        PlayerPrefs.Save();
    }

    // Method to reset the mission progress
    public void ResetMissionProgress()
    {
        PlayerPrefs.DeleteKey(missionProgressKey);
        PlayerPrefs.Save();
    }
}

