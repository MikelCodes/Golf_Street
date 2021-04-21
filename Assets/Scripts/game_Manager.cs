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
    public Text win_Text;
    public bool Win;

    void Start ()
    {
        timer = timerStart;
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
            if (Win == false)
            {
                timer -= Time.deltaTime;

                timer_Text.text = "Time Remaining " + timerStart + " Seconds";
            }
            else
            {
                win();
            }
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

    void win ()
    {
        win_Text.text = "you win";
    }
}
