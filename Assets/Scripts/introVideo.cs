using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class introVideo : MonoBehaviour
{
    public VideoPlayer player;
    public AudioSource introSong;
    // Start is called before the first frame update
    void Start()
    {
        player.Play();
        introSong.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
