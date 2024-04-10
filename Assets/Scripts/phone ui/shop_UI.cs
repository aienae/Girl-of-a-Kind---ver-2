using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shop_UI : MonoBehaviour
{
    [System.Serializable]
    public class Shopitem
    {
        public string itemName;
        public int itemCost;
        public int inventoryCount;
    }

    public TMP_Text displayBalance;
    public TMP_Text displayBalanceHUD;
    public int currentBalance = 500;

    public GameObject itemButton1;
    public GameObject itemButton2;
    public TMP_Text[] inventoryTexts;
    public Shopitem[] items;
    public GameObject cashPic;
    public TMP_Text cashText;



    void Start()
    {
        UpdateBalanceDisplay();
        UpdateInventoryDisplay();

        cashPic.SetActive(false);

        if (PlayerPrefs.GetInt("ActivateCanvas") == 1)
        {
            cashPic.SetActive(true);
            PlayerPrefs.SetInt("ActivateCanvas", 0);
        }

        if (PlayerPrefs.GetInt("PaidMax") == 1)
        {
            cashText.text = ("+$450");
            currentBalance = currentBalance + 450;
            displayBalance.text = "Balance: $" + currentBalance.ToString();
            displayBalanceHUD.text = "$" + currentBalance.ToString();
            PlayerPrefs.SetInt("ActivateCanvas", 0);
        }

        else
        {
            cashText.text = ("+$200");
            currentBalance = currentBalance + 200;
            displayBalance.text = "Balance: $" + currentBalance.ToString();
            displayBalanceHUD.text = "$" + currentBalance.ToString();
            PlayerPrefs.SetInt("ActivateCanvas", 0);
        }


    }


    public void BuyItemClicked(int itemIndex)
    {

        if (currentBalance >= items[itemIndex].itemCost)
        {
            currentBalance -= items[itemIndex].itemCost;
            items[itemIndex].inventoryCount++;
            UpdateBalanceDisplay();
            UpdateInventoryDisplay();
        }
        else
        {
            Debug.Log("not enough money to make purchase!");
        }
    }

    public void UpdateBalanceDisplay()
    {
        displayBalance.text = "Balance: $" + currentBalance.ToString();
        displayBalanceHUD.text = "$" + currentBalance.ToString();
    }

    public void UpdateInventoryDisplay()
    {
        for (int i = 0; i < items.Length; i++)
        {
            inventoryTexts[i].text = items[i].inventoryCount.ToString();
        }
    }
}

    

    