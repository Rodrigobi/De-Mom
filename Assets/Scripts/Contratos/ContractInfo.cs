using UnityEngine;
using System;
using System.Collections.Generic;

public class ContractInfo : MonoBehaviour
{
    public QuestionDialogUI questionDialog;

    private void Start()
    {
        questionDialog = GetComponent<QuestionDialogUI>();

        if (questionDialog == null)
        {
            Debug.LogError("QuestionDialogUI component not found on the ContractInfo object.");
        }
        else
        {
            ShowContractInfo();
        }
    }

    private void ShowContractInfo()
    {
        // Check the contract data and show the appropriate question dialog
        bool demonicVisa = ContractData.Instance.demonicVisa;
        bool organDonor = ContractData.Instance.organDonor;
        bool payWithLife = ContractData.Instance.payWithLife;

        // Create a list of options based on the contract data
        List<string> options = new List<string>();
        if (demonicVisa) options.Add("Demonic Visa");
        if (organDonor) options.Add("Organ Donor");
        if (payWithLife) options.Add("Pay with Life");

        // Create a list of default values
        List<bool> defaultValues = new List<bool> { demonicVisa, organDonor, payWithLife };

        // Show the question dialog with the options
        questionDialog.ShowQuestionWithOptionsAndToggles("Verify the contract information:", options, defaultValues, AcceptContract, DenyContract);
    }

    private void AcceptContract()
    {
        // Implement the logic for accepting the contract
        Debug.Log("Contract accepted");
    }

    private void DenyContract()
    {
        // Implement the logic for denying the contract
        Debug.Log("Contract denied");
    }
}
