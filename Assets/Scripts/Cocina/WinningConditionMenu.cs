using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningConditionMenu : MonoBehaviour
{
    private int remainingServings;
    private int maxServings = 5;
    public Text servingsText;
    public Button serveButton;

    private void Start()
    {
        remainingServings = maxServings;
        UpdateServingsText();
        serveButton.interactable = false; // Disable the button initially
    }

    public void ServeFood()
    {
        remainingServings--;

        if (remainingServings <= 0)
        {
            // Change the food request or perform other desired actions
            ChangeFoodRequest();

            // Reset the scene
            ResetScene();
        }

        UpdateServingsText();
    }

    public void CheckDropSlots(int itemCount)
    {
        serveButton.interactable = itemCount > 0;
    }

    private void ChangeFoodRequest()
    {
        // TODO: Implement logic to change the food request
    }

    private void ResetScene()
    {
        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void UpdateServingsText()
    {
        servingsText.text = "Remaining Servings: " + remainingServings.ToString();
    }
}
