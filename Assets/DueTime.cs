using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DueTime : MonoBehaviour
{
    public int Due = 19; //initial time assignment is due
    public int Current = 00; //Current time

    public bool Extension; //bool to see if extension is requested
    public bool TextChange; //Bool to change extension text


    public Text duetime; //text to display due time
    public Text currenttime; //text to display current time
    public Text ExtensionText; //text element to display extension granted/denied
   

    public float TimeChange; //float to control speed of time progression
    public float Wait; //wait time before extension granted or denied

    public float DeleteTextTime; //float to clear extension notification

    // Start is called before the first frame update
    void Start()
    {
        TimeChange = 3f; //time moves forward every 3 seconds
        Wait = 9f; //wait 9 seconds for extension request
        DeleteTextTime = 1f; //Notification clears after 1 second
        TextChange = false; //text isn't changing by default
    }

    // Update is called once per frame
    void Update()
    {
        TimeChange -= Time.deltaTime; //time is progressing by default

        if (TimeChange < 0) //increases time by one every 3 seconds
        {
            TimeChange = 3;
            Current = Current + 1;
        }
        if (Current == Due) //if current time is equal to due time, you lose and loads lose screen
        {
            //Debug.Log("You Lose");
            SceneManager.LoadScene("LoseScene");
        }
        duetime.text = "Assignment Due: 11:" + Due; //due time text eleemnt always updating
        if (Current < 10) //cleans up formatting for current time if below 10
        {
            currenttime.text = "11:0" + Current;
        }
        else if (Current >= 10) //cleans up formatting for current time if above 10
        {
            currenttime.text = "11:" + Current;
        }

        if (TextChange == true) //if extension text is changing, update text and delete after 1 second
        {
            DeleteTextTime -= Time.deltaTime;
            if (DeleteTextTime < 0)
            {
                ExtensionText.text = "";
                TextChange = false;
                DeleteTextTime = 1f;
            }
        }


        if (Extension == true) //if extension is requested and can be given
        {
            Wait -= Time.deltaTime; //start countdown
            if (Wait < 0) //when timer hits 0, add 10 minutes to due time, update text, and reset bools and floats
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

    public void RequestExtension() //function to control extension request
    {
        if (Due < 59) //if current due time is before 11:59, you can request an extension
        {
            Extension = true;
        }
        else //else it is denied and text is updated
        {
            //Debug.Log("Extension Denied");
            ExtensionText.text = "Extension Denied";
            TextChange = true;
        }
    }
}
