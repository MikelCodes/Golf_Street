using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_Manager : MonoBehaviour
{
    private float timer;
    public int timerInt;
    public Text timer_Text;

    void Start ()
    {
        timer = timerInt;
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
            
            timer_Text.text = "Time Remaining " + timerInt + " Seconds";
        }
        Debug.Log(timer);

        if (timer <= (timerInt - 1))
        {
            timerInt--;
        }
    }

    void timerEnd()
    {
        
    }
}
