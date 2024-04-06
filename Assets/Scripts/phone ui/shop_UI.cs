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
    public int currentBalance = 500;

    public GameObject itemButton1;
    public GameObject itemButton2;
    public TMP_Text[] inventoryTexts;
    public Shopitem[] items;

    
    void Start()
    {
       UpdateBalanceDisplay();
       UpdateInventoryDisplay();
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
    }

    public void UpdateInventoryDisplay()
    {
       for (int i = 0; i < items.Length; i++)
        {
            inventoryTexts[i].text = items[i].inventoryCount.ToString();
        }
    }
}
