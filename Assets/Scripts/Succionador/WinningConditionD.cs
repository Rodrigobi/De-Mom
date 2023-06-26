using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinningConditionD : MonoBehaviour
{
    public int targetEnemyCount = 30;
    private int currentEnemyCount = 0;

    public TMP_Text enemyCountText;


    private void Start()
    {
        // Reset the current enemy count
        currentEnemyCount = 0;
        UpdateEnemyCountText();
    }

    public void IncrementEnemyCount()
    {
        currentEnemyCount++;

        // Check if the target enemy count has been reached
        if (currentEnemyCount >= targetEnemyCount)
        {
            // Call the winning condition function
            WinGame();
        }

        UpdateEnemyCountText();
    }

    private void WinGame()
    {
        // Implement the winning condition logic here
        Debug.Log("Congratulations! You have won the game!");
    }

    private void UpdateEnemyCountText()
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = $"Fantasmas: {currentEnemyCount}/{targetEnemyCount}";
        }
    }
}