using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DueTime : MonoBehaviour
{
    public int Due = 19;
    public int Current = 00;

    public bool Extension;
    public bool TextChange;


    public Text duetime;
    public Text currenttime;
    public Text ExtensionText;
   

    public float TimeChange;
    public float Wait;

    public float DeleteTextTime;
    // Start is called before the first frame update
    void Start()
    {
        TimeChange = 3f;
        Wait = 9f;
        DeleteTextTime = 1f;
        TextChange = false;
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
            //Debug.Log("You Lose");
            SceneManager.LoadScene("LoseScene");
        }
        duetime.text = "Assignment Due: 11:" + Due;
        if (Current < 10)
        {
            currenttime.text = "11:0" + Current;
        }
        else if (Current >= 10)
        {
            currenttime.text = "11:" + Current;
        }

        if (TextChange == true)
        {
            DeleteTextTime -= Time.deltaTime;
            if (DeleteTextTime < 0)
            {
                ExtensionText.text = "";
                TextChange = false;
                DeleteTextTime = 1f;
            }
        }


        if (Extension == true)
        {
            Wait -= Time.deltaTime;
            if (Wait < 0)
            {
                Due = Due + 10;
                //Debug.Log("Extension Granted");
                ExtensionText.text = "Extension Granted";
                Wait = 9f;
                Extension = false;
                TextChange = true;
            }
        }

    }

    public void RequestExtension()
    {
        if (Due < 59)
        {
            Extension = true;
           
            

        }
        else
        {
            
                //Debug.Log("Extension Denied");
            ExtensionText.text = "Extension Denied";
            TextChange = true;
            


        }
    }
}
