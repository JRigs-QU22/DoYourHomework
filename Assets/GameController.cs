using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play() //function for button that loads main game level
    {
        SceneManager.LoadScene("MainGame"); 
    }

    public void MainMenu() //function for button that loads main menu level
    {
        SceneManager.LoadScene("MainMenu");
    }
}
