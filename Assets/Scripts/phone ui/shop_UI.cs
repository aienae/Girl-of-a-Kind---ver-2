using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shop_UI : MonoBehaviour
{
    public Inventory inventory;

    public TMP_Text displayBalance;
    public TMP_Text displayBalanceHUD;

    public GameObject itemButton1;
    public GameObject itemButton2;
    public TMP_Text[] inventoryTexts;
    public GameObject cashPic;
    public TMP_Text cashText;



    void Start()
    {
        UpdateBalanceDisplay();
        UpdateInventoryDisplay();

        cashPic.SetActive(inventory.earnedMoney);

        if (inventory.paidMax)
        {
            cashText.text = ("+$450");
        }
        else
        {
            cashText.text = ("+$200");
        }

        inventory.DisplayBalance(displayBalance, displayBalanceHUD);
    }


    public void BuyItemClicked(int itemIndex)
    {

        if (inventory.BuyItem(itemIndex))
        {
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
        inventory.DisplayBalance(displayBalance, displayBalanceHUD);
    }

    public void UpdateInventoryDisplay()
    {
        inventory.DisplayInventory(inventoryTexts);
    }
}

    

    