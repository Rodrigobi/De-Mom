using UnityEngine;
using UnityEngine.UI;

public class MinimapController : MonoBehaviour
{
    public GameObject minimap; // Reference to the minimap GameObject
    public Button toggleButton; // Reference to the button component
    private bool isMinimapVisible = true; // Flag to track the visibility state of the minimap

    private void Start()
    {
        toggleButton.onClick.AddListener(ToggleMinimap);
    }

    private void ToggleMinimap()
    {
        isMinimapVisible = !isMinimapVisible;
        minimap.SetActive(isMinimapVisible);
    }
}
