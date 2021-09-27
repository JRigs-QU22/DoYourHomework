using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class WorkCompletion : MonoBehaviour
{
    public float MaxCharacters; //float to control assignment completion
    public float Completion; //float value of points needed to win
    public float EnergyLevel; // player energy level
    
    public bool isWorking; //bool to see if player is working

    public VideoPlayer VideoPlay; //public video player component

    public Slider CompletionBar; //slider for player progress
    public Slider Energy; //slider for player energy

    public Text LowEnergy; //text element for a low energy warning

    // Start is called before the first frame update
    void Start()
    {
        MaxCharacters = 0; //sets initial value to 0
        Completion = 0; //sets initial value to 0
        isWorking = false; //player isn't workuing by deault
        EnergyLevel = 70f; //Energy value starts at 70
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) //if any key is pressed, add 1 to Max Characters and decrease energy by 0.1 (in addition to static decreasement)
        {
            MaxCharacters = MaxCharacters + 1;
            EnergyLevel = EnergyLevel - 0.1f;
        }
        if(MaxCharacters > 0) //if MaxCharacters is greater than 0, player is working
        {
            isWorking = true;
        }
        if (MaxCharacters >= 5) //if player is greater than or equal to 4, set MaxCharacters to 1 (to prevent bool swap) and add 1 point to completion (200 needed to win)
        {
            MaxCharacters = 1;
            Completion = Completion + 1;
        }
        CompletionBar.value = Completion; //add value to progress bar

        if (isWorking == true) //if player is working, decrease energy levels
        {
            EnergyLevel -= Time.deltaTime;
        }
        else //otherwise recover energy levels
        {
            EnergyLevel += Time.deltaTime;

            if (EnergyLevel >= 70) //if energy is greater than 70, cap at 70
            {
                EnergyLevel = 70;
            }
        }
        Energy.value = EnergyLevel; //adjust energy bar with current value


        if(isWorking == true) //if player is working, pause video
        {
            VideoPlay.Pause();
        }
        else //if player isn't working play video and set MaxCharacters to 0 to keep bool from swapping
        {
            VideoPlay.Play();
            MaxCharacters = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return)) //if player hits enter, player isn't working and set MaxCharacters to 0 to keep bool from swapping
        {
            isWorking = false;
            MaxCharacters = 0;
        }

        if (EnergyLevel <= 10) //if Energy is 10 or below, show warning
        {
            LowEnergy.text = "ENERGY LOW!!!";
        }
        else //otherwise text is empty
        {
            LowEnergy.text = "";
        }
        if(EnergyLevel <= 0) //ig energy is 0, load lose screen
        {
            SceneManager.LoadScene("LoseScene");
        }
        else if (Completion == 200) //if progress equals 200, load win screen
        {
            SceneManager.LoadScene("WinScene");
        }


    }
}
