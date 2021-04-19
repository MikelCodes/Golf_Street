using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_Manager : MonoBehaviour
{
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timerEnd();
        }
        else
        {
            timer -= Time.deltaTime;
        }
        Debug.Log(timer);
    }

    void timerEnd()
    {

    }
}
