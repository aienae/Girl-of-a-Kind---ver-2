using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OpenPhone : MonoBehaviour
{

    public Canvas phoneCanvas;
    public GameObject phoneButton;
    public GameObject closePhoneButton;

    public GameObject phonePrefab;
    public Transform phoneSpawnPoint;

    private GameObject phoneInstance;

    public DestroyPhone DestroyPhone;

    public AudioSource audioSource;
    public AudioClip clickSound;
    

    // Start is called before the first frame update
    void Start()
    {
        phoneCanvas.enabled = false;
        
    }

    public void SpawnPhone()
    {
        phoneInstance = Instantiate(phonePrefab, phoneSpawnPoint.position, phoneSpawnPoint.rotation);
        DestroyPhone destroyPhone = phoneInstance.GetComponent<DestroyPhone>();
        destroyPhone.phoneCanvas = phoneCanvas;

        Animator phoneAnimator = phoneInstance.GetComponent<Animator>();

        if (phoneAnimator != null)
        {
            Debug.LogError("animator not found in script");
        }

    }

    
    public void PhoneToggleOn()
    {
        audioSource.PlayOneShot(clickSound);
        phoneButton.SetActive(false);
        SpawnPhone();
        
    }


    public void CloseButtonClicked ()
    {
        phoneCanvas.enabled = false;
        phoneButton.SetActive(true);
    }

}
