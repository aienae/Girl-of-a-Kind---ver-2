using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazine : MonoBehaviour
{
    
    public GameObject magazinePage1;
    public GameObject magazinePage2;
    public GameObject closeButton;
    public GameObject nextButton;
    public GameObject talkButton;
    

    // Start is called before the first frame update
    void Start()
    {
        magazinePage2.SetActive(false);
        magazinePage1.SetActive(false);
        closeButton.SetActive(false);
        nextButton.SetActive(false);
    }

    // Update is called once per frame
    public void HUDmagClicked()
    {
        magazinePage1.SetActive(true);
        closeButton.SetActive(true);
        nextButton.SetActive(true);
        talkButton.SetActive(false);
    }

    public void nextClicked()
    {
        magazinePage2.SetActive(true);
        magazinePage1.SetActive(false);
    }


    public void magClickedClose()
    {
        magazinePage2.SetActive(false);
        magazinePage1.SetActive(false);
        closeButton.SetActive(false);
        talkButton.SetActive(true);
    }
}
