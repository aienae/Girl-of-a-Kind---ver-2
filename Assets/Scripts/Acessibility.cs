using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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
        TMP_Dropdown[] dropdownObject = Resources.FindObjectsOfTypeAll<TMP_Dropdown>();
        Slider[] slider = Resources.FindObjectsOfTypeAll<Slider>();

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
        //change name of game scene below to the game scenes name
        SceneManager.LoadScene("shop");
    }


}
