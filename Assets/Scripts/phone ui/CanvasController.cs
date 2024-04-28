using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject childMainMenu;
    public GameObject childShopMenu;
    public GameObject childInvenMenu;

    public Button shoppingButton;
    public Button shopBackButton;

    public Button InventoryButton;
    public Button InvenBackButton;

    public AudioSource audioSource;
    public AudioClip clickSound;

    // Start is called before the first frame update
    void Start()
    {
        //childInvenMenu.SetActive(false);
        //childShopMenu.SetActive(false);
        childMainMenu.SetActive(true);
    }

    public void ShopButtonClicked()
    {
        audioSource.PlayOneShot(clickSound);
        childMainMenu.SetActive(false);
        childShopMenu.SetActive(true);
        childInvenMenu.SetActive(false);
    }
    public void ShopBackClicked()
    {
        audioSource.PlayOneShot(clickSound);
        audioSource.PlayOneShot(clickSound);
        childShopMenu.SetActive(false);
        childMainMenu.SetActive(true);

    }

    public void InventoryButtonClicked()
    {
        audioSource.PlayOneShot(clickSound);
        childMainMenu.SetActive(false);
        childInvenMenu.SetActive(true);
        childShopMenu.SetActive(false);

    }
        public void InvenBackClicked()
    {
        audioSource.PlayOneShot(clickSound);
        childInvenMenu.SetActive(false);
        childMainMenu.SetActive(true);

    }
}
