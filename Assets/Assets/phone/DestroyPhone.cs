using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPhone : MonoBehaviour
{

    public bool phoneDestroyed;
    public Canvas phoneCanvas;
    public void DestroyPhoneObject()
    {
        phoneCanvas.enabled = true;
        Destroy(gameObject);
       
    }
}
