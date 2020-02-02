using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Timer : MonoBehaviour
{
    public int countDownStartValue = 5;
    public Text timerUI;



    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan SpanTime = TimeSpan.FromSeconds(countDownStartValue);
            timerUI.text = "Timer : " + SpanTime.Minutes + " : " + SpanTime.Seconds;
            // print("Timer : " + countDownStartValue);
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            timerUI.text = "Game Over";
            print("Game Over");
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
