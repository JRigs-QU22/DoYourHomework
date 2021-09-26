using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class WorkCompletion : MonoBehaviour
{
    public float MaxCharacters;
    public float Completion;
    public float EnergyLevel;
    //public float EverySecond = 1f;
    public bool isWorking;
    public VideoPlayer VideoPlay;
    public Slider CompletionBar;
    public Slider Energy;

    public Text LowEnergy;

    // Start is called before the first frame update
    void Start()
    {
        MaxCharacters = 0;
        Completion = 0;
        isWorking = false;
        EnergyLevel = 70f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            MaxCharacters = MaxCharacters + 1;
            EnergyLevel = EnergyLevel - 0.1f;
        }
        if(MaxCharacters > 0)
        {
            isWorking = true;
        }
        if (MaxCharacters >= 5)
        {
            MaxCharacters = 1;
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

            if (EnergyLevel >= 70)
            {
                EnergyLevel = 70;
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
            MaxCharacters = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isWorking = false;
            MaxCharacters = 0;
        }

        if (EnergyLevel <= 10)
        {
            LowEnergy.text = "ENERGY LOW!!!";
        }
        else
        {
            LowEnergy.text = "";
        }
        if(EnergyLevel <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
        else if (Completion == 200)
        {
            SceneManager.LoadScene("WinScene");
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
