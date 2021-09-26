using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer Pausable;

    public bool isPlaying;

    public WorkCompletion WC;

    // Start is called before the first frame update
    void Start()
    {
        Pausable = this.GetComponent<VideoPlayer>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WC.isWorking == false)
        {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }
    }
}
