using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.Audio;

public class Acessibility : MonoBehaviour
{
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject creditsButton;
    public GameObject backButton;

    public string[] scenesInGame;

    public AudioSource audioSource;
    public AudioClip clickSound;
    public GameObject credits;

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

    private float fieldOfVisionValue;
    public Slider sliderFOV;
    public TextMeshProUGUI sliderNumbText;

    public Slider musicSlider;
    public AudioMixer mainMixer;
    public Slider soundSlider;

    const string MIXER_MUSIC = "Music Volume";
    const string MIXER_SOUND = "Sound Volume";

    private void Awake()
    {
        for (int i = 0; i < scenesInGame.Length; i++)
        {
            SceneManager.LoadSceneAsync(scenesInGame[i], LoadSceneMode.Additive);
        }
    }

    void Start()
    {

        credits.SetActive(false);
        backButton.SetActive(false);
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
            if (gameObjectsFound[i].name == "MMObjects")
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
            if (slider[i].name == "Music Volume Slider")
            {
                musicSlider = slider[i];
            }
            if (slider[i].name == "Sound Volume Slider")
            {
                soundSlider = slider[i];
            }
            if (slider[i].name == "FOV Slider")
            {
                sliderFOV = slider[i];
            }
        }

        for (int i = 0; i < text.Length; i++)
        {
            defaultTextSize.Add(text[i].fontSize);
        }

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        soundSlider.onValueChanged.AddListener(SetSoundVolume);

        fieldOfVisionValue = sliderFOV.value;
        sliderNumbText.text = "FOV: " + fieldOfVisionValue.ToString();
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

    public void TextSliderChange()
    {
        for (int i = 0; i < text.Length; i++)
        {
            textSliderValue = textSlider.value;
            text[i].fontSize = defaultTextSize[i] * textSliderValue;
        }
    }

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
        audioSource.PlayOneShot(clickSound);
        Debug.Log("settings");
        inSettings = !inSettings;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Break();
    }

    public void Credits()
    {
        audioSource.PlayOneShot(clickSound);
        credits.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        creditsButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void backToMainMenuButton()
    {
        audioSource.PlayOneShot(clickSound);
        credits.SetActive(false);
        playButton.SetActive(true);
        settingsButton.SetActive(true);
        creditsButton.SetActive(true);
       backButton.SetActive(false);

    }

    void SetMusicVolume(float value)
    {
        mainMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }    
    
    void SetSoundVolume(float value)
    {
        mainMixer.SetFloat(MIXER_SOUND, Mathf.Log10(value) * 20);
    }    

    public void SetFOV()
    {
        fieldOfVisionValue = sliderFOV.value;
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].m_Lens.FieldOfView = fieldOfVisionValue;
        }
        sliderNumbText.text = "FOV: " + fieldOfVisionValue.ToString();
    }

    public void PlayGame()
    {
        audioSource.PlayOneShot(clickSound);
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
