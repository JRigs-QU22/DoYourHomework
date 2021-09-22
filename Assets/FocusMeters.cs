using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FocusMeters : MonoBehaviour
{
    public bool isWorking;
    public bool isWatching;

    public int WorkFocus;
    public int VideoFocus;

    public float Countdown;

    public Text WorkText;
    public Text VideoText;

    // Start is called before the first frame update
    void Start()
    {
        Countdown = 1f;
        WorkFocus = 50;
        VideoFocus = 50;

        isWorking = false;
        isWatching = false;

        WorkText.text = "Work Forcus: " + WorkFocus;
        VideoText.text = "Video Focus: " + VideoFocus;

    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking)
        {
            
            Countdown -= Time.deltaTime;
            if (Countdown < 0)
            {
                WorkFocus = WorkFocus + 2;
                VideoFocus = VideoFocus - 1;
                Countdown = 1f;
               // Debug.Log(WorkFocus);
               // Debug.Log(VideoFocus);
            }
        }
        else if (isWatching)
        {
            
            Countdown -= Time.deltaTime;
            if (Countdown < 0)
            {
                WorkFocus = WorkFocus - 1;
                VideoFocus = VideoFocus + 2;
                Countdown = 1f;
               // Debug.Log(WorkFocus);
                //Debug.Log(VideoFocus);
            }
        }
        if (WorkFocus == 0 || VideoFocus == 0)
        {
            //Debug.Log ("You Lose");
            SceneManager.LoadScene("LoseScene");
        }

        WorkText.text = "Work Forcus: " + WorkFocus;
        VideoText.text = "Video Focus: " + VideoFocus;
    }

    public void Working()
    {
        //if (gameObject.tag == "Work")
        isWorking = true;
        isWatching = false;

    }

    public void Playing()
    {
        //if (gameObject.tag == "Work")
        
            isWorking = false;
            isWatching = true;
        

    }
}
