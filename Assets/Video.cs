using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer Pausable; //public video player component

    public bool isPlaying; //bool to see if video is playing

    public WorkCompletion WC; //public Work Completion script to allow interaction with other script

    // Start is called before the first frame update
    void Start()
    {
        Pausable = this.GetComponent<VideoPlayer>(); //sets video player
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WC.isWorking == false) //if player isn't working, play video
        {
            isPlaying = true;
        }
        else // otherwise pause video
        {
            isPlaying = false;
        }
    }
}
