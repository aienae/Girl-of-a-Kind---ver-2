using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class introVideo : MonoBehaviour
{
    public VideoPlayer player;
    public AudioSource introSong;
    public float videoTime;
    public RawImage videoImage;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextScene", videoTime);
    }

    // Update is called once per frame
    void NextScene()
    {
        videoImage.enabled = false;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
