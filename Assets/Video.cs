using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer Pausable;
    // Start is called before the first frame update
    void Start()
    {
        Pausable = this.GetComponent<VideoPlayer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Pausable =  this.GetComponent<Video>();
        if (Input.GetKeyDown (KeyCode.Space))
        {
            Pausable.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Pausable.Play();
        }
    }
}
