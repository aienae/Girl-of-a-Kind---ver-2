using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EarnMoney : MonoBehaviour
{
    public GameObject cashPic;
    public TMP_Text cashText;

    void Start()
    {
        cashPic.SetActive(false);

        if (PlayerPrefs.GetInt("ActivateCanvas") == 1)
        {
            cashPic.SetActive(true);
            PlayerPrefs.SetInt("ActivateCanvas", 0);
        }

        if (PlayerPrefs.GetInt("PaidMax") == 1)
        {
            cashText.text = ("+$450");
            PlayerPrefs.SetInt("ActivateCanvas", 0);
        }

        else
        {
            cashText.text = ("+$200");
            PlayerPrefs.SetInt("ActivateCanvas", 0);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
