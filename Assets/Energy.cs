using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Energy : MonoBehaviour
{
    public bool isWorking;
    public float WorkEnergy;

    public GameObject Work;
    public GameObject Video;

    // Start is called before the first frame update
    void Start()
    {
        WorkEnergy = 100;
        isWorking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking)
        {
            WorkEnergy -= Time.deltaTime;
        }
        else
        {
            WorkEnergy += Time.deltaTime;
        }

        if (WorkEnergy > 100)
        {
            WorkEnergy = 100;
        }

        if (WorkEnergy < 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

   public void OnMouseDown()
    {
        Debug.Log("Clicked");
        if (gameObject.tag == "Work")
        {
            isWorking = true;
        }

        if (gameObject.tag == "Video")
        {
            isWorking = false;
        }
    }
}
