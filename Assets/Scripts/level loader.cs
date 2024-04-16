using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelloader : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip cashSound;


    // Start is called before the first frame update
    public void ClickDesignStation(string DesignStation)
    {
        SceneManager.LoadScene(DesignStation);
    }

    public void FinishPayClicked(string shop)
    {
        PlayerPrefs.SetInt("ActivateCanvas", 1);
        audioSource.PlayOneShot(cashSound);
        SceneManager.LoadScene(shop);
    }
        
}
