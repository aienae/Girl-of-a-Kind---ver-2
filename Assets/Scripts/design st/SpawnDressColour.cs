using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnDressColour : MonoBehaviour
{
    public GameObject PinkDress;
    public GameObject BlueDress;
    public GameObject BlackDress;
    public GameObject yellowDress;
    public Button ButtonPink;
    public Button ButtonBlue;
    public Button ButtonBlack;
    public Button ButtonYellow;
    public Rotate rotator;

    public GameObject spawnedObject;
    public OrderManager orderManager;

    public void ButtonPressed()
    {
         
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ButtonPink);
        ButtonPink.onClick.AddListener(SpawnPink);
        ButtonBlue.onClick.AddListener(SpawnBlue);
        ButtonBlack.onClick.AddListener(SpawnBlack);
        ButtonYellow.onClick.AddListener(SpawnYellow);
    }

    void SpawnDress(GameObject dressPrefab)
    {
        if (spawnedObject != null)
            Destroy(spawnedObject);

        spawnedObject = Instantiate(dressPrefab, transform.position, Quaternion.identity);
        rotator.objectToRotate = spawnedObject;
        orderManager.SpawnDressColour = dressPrefab.name;
    }

    void SpawnYellow()
    {
        SpawnDress(yellowDress);
    }
    void SpawnPink()
    {
        SpawnDress(PinkDress);
    }

    void SpawnBlue()
    {
        SpawnDress(BlueDress);
    }

    void SpawnBlack()
    {
        SpawnDress(BlackDress);
    }

    void Update()
    {
        
    }
}
