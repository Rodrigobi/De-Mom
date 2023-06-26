using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionDialogUI : MonoBehaviour
{
    public static QuestionDialogUI Instance { get; private set; }

    public TextMeshProUGUI questionText;
    public List<Toggle> optionToggles;
    public Button acceptButton;
    public Button denyButton;

    private Action acceptAction;
    private Action denyAction;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowQuestionWithOptionsAndToggles(string question, List<string> options, List<bool> defaultValues, Action accept, Action deny)
    {
        questionText.text = question;
        acceptAction = accept;
        denyAction = deny;

        for (int i = 0; i < optionToggles.Count; i++)
        {
            if (i < options.Count)
            {
                optionToggles[i].gameObject.SetActive(true);
                optionToggles[i].isOn = defaultValues[i];
                optionToggles[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = options[i];
            }
            else
            {
                optionToggles[i].gameObject.SetActive(false);
            }
        }

        acceptButton.onClick.AddListener(AcceptClicked);
        denyButton.onClick.AddListener(DenyClicked);

        gameObject.SetActive(true);
    }

    private void AcceptClicked()
    {
        bool allOptionsSelected = true;

        for (int i = 0; i < optionToggles.Count; i++)
        {
            if (optionToggles[i].gameObject.activeSelf && !optionToggles[i].isOn)
            {
                allOptionsSelected = false;
                break;
            }
        }

        if (allOptionsSelected)
        {
            Debug.Log("Contract Accepted!");
            acceptAction?.Invoke();
        }
        else
        {
            Debug.Log("Contract Conditions not met!");
        }

        Hide();
    }

    private void DenyClicked()
    {
        Debug.Log("Contract Denied!");
        denyAction?.Invoke();
        Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
