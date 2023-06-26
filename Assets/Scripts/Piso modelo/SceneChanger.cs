using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // The name of the scene you want to load
    public Button button; // Reference to the button component

    private void Start()
    {
        // Attach the ChangeScene method to the button's onClick event
        button.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
