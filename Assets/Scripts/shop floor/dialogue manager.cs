using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class dialoguemanager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Canvas canvasDialogue;
    public Canvas canvasButton;
    public TMP_Text orderText;

    

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        canvasDialogue.enabled = false;
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    
    public void StartDialogue (Dialogue dialogue)
    {
        canvasDialogue.enabled = true;
        canvasButton.enabled = true;
        nameText.text = dialogue.name;
        orderText.text = dialogue.order;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count ==0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    void EndDialogue() 
    {
        Debug.Log("end of convo");
        canvasDialogue.enabled = false;
        canvasButton.enabled = true;
    }
}
