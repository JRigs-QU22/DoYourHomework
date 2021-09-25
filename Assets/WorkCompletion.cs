using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkCompletion : MonoBehaviour
{
    public float MaxCharacters;
    // Start is called before the first frame update
    void Start()
    {
        MaxCharacters = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            MaxCharacters = MaxCharacters + 1;
        }
        
    }
}
