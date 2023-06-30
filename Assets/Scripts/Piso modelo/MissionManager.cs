using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    // PlayerPrefs key to store mission progress
    private string missionProgressKey = "MissionProgress";

    // Number of NPCs to talk to
    public int totalNPCs = 6;

    private int missionProgress; // Current mission progress

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
            // Initialize the mission progress
            missionProgress = 0;
        }
    }

    // Method to update the mission progress based on the current scene
    public void UpdateMissionProgress(string npcTag)
    {
        // Check if the NPC is part of the mission
        if (npcTag.StartsWith("NPC"))
        {
            // Extract the NPC number from the tag
            int npcNumber = int.Parse(npcTag.Substring(3));

            // Check if the NPC has not been talked to yet
            if ((missionProgress & (1 << npcNumber)) == 0)
            {
                // Mark the NPC as talked to
                missionProgress |= (1 << npcNumber);
            }
        }
    }

    // Method to check if the mission is completed
    public bool IsMissionCompleted()
    {
        // Check if all NPCs have been talked to
        return missionProgress == (1 << totalNPCs) - 1;
    }

    // Method to reset the mission progress
    public void ResetMissionProgress()
    {
        // Reset the mission progress
        missionProgress = 0;
        PlayerPrefs.DeleteKey(missionProgressKey);
    }

    // Save the mission progress when the scene changes
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SaveMissionProgress;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SaveMissionProgress;
    }

    private void SaveMissionProgress(Scene scene, LoadSceneMode mode)
    {
        PlayerPrefs.SetInt(missionProgressKey, missionProgress);
        PlayerPrefs.Save();
    }
}
