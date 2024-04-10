using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public Dialogue Dialogue; // reference to the dialogue script
    public string black;
    public string ribbon2;
    public string SpawnDressColour;
    public string DragAndDrop;

    public TMP_Text finalText;
    public GameObject outcomeCnavas;
    public GameObject wellDoneImage;
    public GameObject oopsImage;
   

    void Start()
    {
        ribbon2 = Dialogue.ribbon2;
        black = Dialogue.black;
        outcomeCnavas.SetActive(false);
        oopsImage.SetActive(false);
        wellDoneImage.SetActive(false);
    }
    
    public void OnButtonClick()
    {
        outcomeCnavas.SetActive(true);

        if (SpawnDressColour == black && DragAndDrop == ribbon2)
        {
            finalText.text = "perfect! a true fashionista!";
            wellDoneImage.SetActive(true);
            PlayerPrefs.SetInt("PaidMax", 1);
            Debug.Log("order complete!");
        }
        else
        {
            finalText.text = "Looks like you missed some stuff, oops!";
            oopsImage.SetActive(true);
            PlayerPrefs.SetInt("PaidMax", 0);
            Debug.Log("order wasn't completed correctly");
        }


    }



}
