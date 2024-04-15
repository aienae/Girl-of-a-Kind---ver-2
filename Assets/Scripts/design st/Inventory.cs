using System;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    [System.Serializable]
    public class Shopitem
    {
        public string itemName;
        public int itemCost;
        public int inventoryCount;
        public string orderText;
    }
    public Shopitem[] items;
    public int currentBalance = 500;

    public void AddBalance(int amount)
    {
        currentBalance += amount;
    }

    public void DisplayBalance(TMP_Text displayBalance, TMP_Text displayBalanceHUD)
    {
        displayBalance.text = "Balance: $" + currentBalance.ToString();
        displayBalanceHUD.text = "$" + currentBalance.ToString();
    }

    public bool BuyItem(int itemIndex)
    {
        if (currentBalance >= items[itemIndex].itemCost)
        {
            items[itemIndex].inventoryCount++;
            currentBalance -= items[itemIndex].itemCost;
            return true;
        }
        return false;
    }

    public void DisplayInventory(TMP_Text[] inventoryTexts)
    {
        for (int i = 0; i < items.Length; i++)
        {
            inventoryTexts[i].text = items[i].inventoryCount.ToString();
        }
    }
}
