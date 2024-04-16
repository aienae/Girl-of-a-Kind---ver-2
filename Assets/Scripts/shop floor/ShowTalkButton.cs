using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowTalkButton : MonoBehaviour
{
    public GameObject talkButton;
    // Start is called before the first frame update
    void Start()
    {
        talkButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        talkButton.SetActive(true);
    }
}
