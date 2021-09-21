using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DueTime : MonoBehaviour
{
    public int Due = 19;
    public int Current = 00;

    public bool Extension;

    public Text duetime;
    public Text currenttime;
    public Text waittime;

    public float TimeChange;
    public float Wait;

    // Start is called before the first frame update
    void Start()
    {
        TimeChange = 3f;
        Wait = 9f;
    }

    // Update is called once per frame
    void Update()
    {
        TimeChange -= Time.deltaTime;

        if (TimeChange < 0)
        {
            TimeChange = 3;
            Current = Current + 1;
        }
        if (Current == Due)
        {
            Debug.Log("You Lose");
        }
        duetime.text = "Assignment Due: 11:" + Due;
        if (Current < 10)
        {
            currenttime.text = "Current Time: 11:0" + Current;
        }
        else if (Current >= 10)
        {
            currenttime.text = "Current Time: 11:" + Current;
        }


        if (Extension == true)
        {
            Wait -= Time.deltaTime;
            if (Wait < 0)
            {
                Due = Due + 10;
                Debug.Log("Extension Granted");
                Wait = 9f;
                Extension = false;
            }
        }

        waittime.text = "Wait Time: " + Wait;
    }

    public void RequestExtension()
    {
        if (Due < 59)
        {
            Extension = true;
           
            

        }
        else
        {

                Debug.Log("Extension Denied");

            
        }
    }
}
