using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_Manager : MonoBehaviour
{
    public int timerStart;
    public float timer;
    public Text timer_Text;

    void Start ()
    {
        timer = timerStart;    }

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
            
            timer_Text.text = "Time Remaining " + timerStart + " Seconds";
        }
        //Debug.Log(timer);

        if (timer <= (timerStart - 1))
        {
            timerStart--;
        }

    }

    void timerEnd()
    {
        SceneManager.LoadScene(0);
    }
}
