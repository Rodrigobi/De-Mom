using UnityEngine;

public class QuestionDialogInitializer : MonoBehaviour
{
    public QuestionDialogUI questionDialog;

    private void Awake()
    {
        // Remove the line questionDialog.Initialize();
        // The QuestionDialogUI script doesn't require an explicit initialization.
    }
}
