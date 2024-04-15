using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject talkButton;

    public void TriggerDialogue ()
    {
        FindObjectOfType<dialoguemanager>().StartDialogue(dialogue);
        talkButton.SetActive(false);
    }
}
