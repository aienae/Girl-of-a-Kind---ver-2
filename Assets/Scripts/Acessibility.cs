using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Cinemachine;

public class Acessibility : MonoBehaviour
{
    //make sure to add scene names used in the game to this array inside the inspector in unity
    //Example: "MainMenu" "GameScene" etc.
    public string[] scenesInGame;


    public TextMeshProUGUI[] text;
    public Slider textSlider;
    public List<float> defaultTextSize = new List<float>();
    public float textSliderValue;

    public TMP_Dropdown dropdown;
    public TMP_FontAsset[] fontSelection;
    public TMP_FontAsset currentFont;
    public int currentFontNumb;

    public GameObject settingsMenu;
    public GameObject mainMenu;
    public bool inSettings;

    public CinemachineVirtualCamera[] cameras;
    public List<GameObject> mainMenuSceneObjects = new List<GameObject>();
    public List<GameObject> shopSceneObjects = new List<GameObject>();
    public List<GameObject> designStationSceneObjects = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < scenesInGame.Length; i++)
        {
            //uses the array to add scenes additively and helps make the text changing work
            SceneManager.LoadSceneAsync(scenesInGame[i], LoadSceneMode.Additive);
        }
    }

    void Start()
    {
        //everything inside this start function is for setting values
        text = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
        cameras = Resources.FindObjectsOfTypeAll<CinemachineVirtualCamera>();
        GameObject[] gameObjectsFound = Resources.FindObjectsOfTypeAll<GameObject>();
        TMP_Dropdown[] dropdownObject = Resources.FindObjectsOfTypeAll<TMP_Dropdown>();
        Slider[] slider = Resources.FindObjectsOfTypeAll<Slider>();

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = 10;
            if (cameras[i].name == "Menu Virtual Camera")
            {
                cameras[i].Priority = 11;
            }
        }

        for (int i = 0; i < gameObjectsFound.Length; i++)
        {
            if (gameObjectsFound[i].name == "ShopObjects")
            {
                shopSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "ShopLighting")
            {
                shopSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "ShopMenus")
            {
                shopSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "ShopNPCStuff")
            {
                shopSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "ShopManagers")
            {
                shopSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "DSObects")
            {
                designStationSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "DSLighting")
            {
                designStationSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "DSMenus")
            {
                designStationSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "MMMenus")
            {
                mainMenuSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "MMLighting")
            {
                mainMenuSceneObjects.Add(gameObjectsFound[i]);
            }
            if (gameObjectsFound[i].name == "MMAudioAndVideo")
            {
                mainMenuSceneObjects.Add(gameObjectsFound[i]);
            }
        }

        for (int i = 0; i < shopSceneObjects.Count; i++)
        {
            shopSceneObjects[i].SetActive(false);
        }
        for (int i = 0; i < designStationSceneObjects.Count; i++)
        {
            designStationSceneObjects[i].SetActive(false);
        }

        for (int i = 0; i < dropdownObject.Length; i++)
        {
            if (dropdownObject[i].name == "Settings Font Dropdown")
            {
                dropdown = dropdownObject[i];
            }
        }
        for (int i = 0; i < slider.Length; i++)
        {
            if (slider[i].name == "Settings Text Size Slider")
            {
                textSlider = slider[i];
            }
        }

        for (int i = 0; i < text.Length; i++)
        {
            defaultTextSize.Add(text[i].fontSize);
        }
    }

    private void Update()
    {
        if (inSettings == true)
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
    }

    //this function needs to be on the text slider
    public void TextSliderChange()
    {
        for (int i = 0; i < text.Length; i++)
        {
            textSliderValue = textSlider.value;
            text[i].fontSize = defaultTextSize[i] * textSliderValue;
        }
    }

    //this function needs to be on the font dropdown
    public void FontStyleDropdown()
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentFontNumb = dropdown.value;
            currentFont = fontSelection[currentFontNumb];
            text[i].font = currentFont;
        }
    }

    public void SettingsOpenClose()
    {
        Debug.Log("settings");
        inSettings = !inSettings;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Break();
    }

    public void PlayGame()
    {
        for (int i = 0; i < shopSceneObjects.Count; i++)
        {
            shopSceneObjects[i].SetActive(true);
        }
        for (int i = 0; i < mainMenuSceneObjects.Count; i++)
        {
            mainMenuSceneObjects[i].SetActive(false);
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = 10;
            if (cameras[i].name == "Shop Virtual Camera")
            {
                cameras[i].Priority = 11;
            }
        }
    }


}
