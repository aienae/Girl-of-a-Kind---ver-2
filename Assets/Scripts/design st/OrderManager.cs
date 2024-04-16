using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public Inventory inventory;
    public string SpawnDressColour;
    public string DragAndDrop;

    public TMP_Text finalText;
    public GameObject outcomeCnavas;
    


   

    void Start()
    {
        outcomeCnavas.SetActive(false);
        
    }
    
    public void OnButtonClick()
    {
        outcomeCnavas.SetActive(true);

        if (SpawnDressColour == inventory.dress && DragAndDrop == inventory.accessory)
        {
            finalText.text = "perfect! a true fashionista!";
            inventory.AddBalance(450);
            inventory.earnedMoney = true;
            inventory.paidMax = true;
            Debug.Log("order complete!");
        }
        else
        {
            finalText.text = "Looks like you missed some stuff, oops!";
            inventory.AddBalance(200);
            inventory.earnedMoney = true;
            inventory.paidMax = false;
            Debug.Log("order wasn't completed correctly");
        }


    }



}
