using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WorkCompletion : MonoBehaviour
{
    public float MaxCharacters;
    public float Completion;
    public float EnergyLevel;
    //public float EverySecond = 1f;
    public bool isWorking;
    public GameObject VideoObject;
    public GameObject WorkObject;
    public VideoPlayer VideoPlay;
    public Slider CompletionBar;
    public Slider Energy;

    // Start is called before the first frame update
    void Start()
    {
        MaxCharacters = 0;
        Completion = 0;
        isWorking = false;
        EnergyLevel = 50f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            MaxCharacters = MaxCharacters + 1;
        }
        if (MaxCharacters >= 5)
        {
            MaxCharacters = 0;
            Completion = Completion + 1;
        }
        CompletionBar.value = Completion;

        if (isWorking == true)
        {
            EnergyLevel -= Time.deltaTime;
        }
        else
        {
            EnergyLevel += Time.deltaTime;

            if (EnergyLevel >= 50)
            {
                EnergyLevel = 50;
            }
        }
        Energy.value = EnergyLevel;


        if(isWorking == true)
        {
            VideoPlay.Pause();
        }
        else
        {
            VideoPlay.Play();
        }
    }
    private void OnMouseDown()
    {
        if(gameObject.tag == "Work")
        {
            isWorking = true;
            
        }
        if(gameObject.tag == "Video")
        {
            isWorking = false;
        }
         
    }
}
