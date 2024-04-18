using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelloader : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip cashSound;

    private Acessibility acessibilityScript;
    private SpawnDressColour spawnDressScript;

    // Start is called before the first frame update
    private void Start()
    {
        acessibilityScript = GameObject.Find("Acessibility").GetComponent<Acessibility>();

        GameObject[] gameObjectArray = Resources.FindObjectsOfTypeAll<GameObject>();

        for (int i = 0; i < gameObjectArray.Length; i++)
        {
            if (gameObjectArray[i].name == "SpawnDress")
            {
                spawnDressScript = gameObjectArray[i].GetComponent<SpawnDressColour>();
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < acessibilityScript.cameras.Length; i++)
        {
            if (acessibilityScript.cameras[i].name == "DS Virtual Camera" && acessibilityScript.cameras[i].Priority == 10)
            {
                Debug.Log("aaaaaaaaaa");
                Destroy(spawnDressScript.spawnedObject);
            }
        }
    }

    public void ClickDesignStation()
    {
        for (int i = 0; i < acessibilityScript.shopSceneObjects.Count; i++)
        {
            acessibilityScript.shopSceneObjects[i].SetActive(false);
        }
        for (int i = 0; i < acessibilityScript.designStationSceneObjects.Count; i++)
        {
            acessibilityScript.designStationSceneObjects[i].SetActive(true);
        }

        for (int i = 0; i < acessibilityScript.cameras.Length; i++)
        {
            acessibilityScript.cameras[i].Priority = 10;
            if (acessibilityScript.cameras[i].name == "DS Virtual Camera")
            {
                acessibilityScript.cameras[i].Priority = 11;
            }
        }
    }

    public void FinishPayClicked()
    {
        for (int i = 0; i < acessibilityScript.designStationSceneObjects.Count; i++)
        {
            acessibilityScript.designStationSceneObjects[i].SetActive(false);
        }
        for (int i = 0; i < acessibilityScript.shopSceneObjects.Count; i++)
        {
            acessibilityScript.shopSceneObjects[i].SetActive(true);
        }

        PlayerPrefs.SetInt("ActivateCanvas", 1);
        audioSource.PlayOneShot(cashSound);

        for (int i = 0; i < acessibilityScript.cameras.Length; i++)
        {
            acessibilityScript.cameras[i].Priority = 10;
            if (acessibilityScript.cameras[i].name == "Shop Virtual Camera")
            {
                acessibilityScript.cameras[i].Priority = 11;
            }
        }
    }
        
}
