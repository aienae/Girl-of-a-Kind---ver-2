using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject childMainMenu;
    public GameObject childShopMenu;

    public Button shoppingButton;
    public Button shopBackButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShopButtonClicked()
    {
        childMainMenu.SetActive(false);
        childShopMenu.SetActive(true);

    }
    public void ShopBackClicked()
    {
        childShopMenu.SetActive(false);
        childMainMenu.SetActive(true);

    }
}
