using UnityEngine;

public class ContractData : MonoBehaviour
{
    public static ContractData Instance { get; private set; }

    // Define your contract data variables here
    public bool demonicVisa;
    public bool organDonor;
    public bool payWithLife;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetContractData()
    {
        // Access the contract data and set the values
        ContractData.Instance.demonicVisa = true;
        ContractData.Instance.organDonor = false;
        ContractData.Instance.payWithLife = true;
    }


    // Add any necessary methods for managing the contract data
}
