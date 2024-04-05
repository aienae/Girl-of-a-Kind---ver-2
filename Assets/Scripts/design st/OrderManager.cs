using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public Dialogue Dialogue; // reference to the dialogue script
   // public SpawnDressColour SpawnDressColour; // reference to dress script
    //public DragAndDrog DragAndDrop; // reference to drag and drop script
    public string black;
    public string ribbon2;
    public string SpawnDressColour;
    public string DragAndDrop;


    void Start()
    {
        ribbon2 = Dialogue.ribbon2;
        black = Dialogue.black;

    }
    
    public void OnButtonClick()
    {
        if (SpawnDressColour == black && DragAndDrop == ribbon2)
        {
            Debug.Log("order complete!");
        }
        else
        {
            Debug.Log("order wasn't completed correctly");
        }
    }
}
