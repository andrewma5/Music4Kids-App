using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private int minutes = 0;
    private int seconds = 0;

    private int counter = 0;

    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        minutes = 1;
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        counter++;
        if (counter >= 50)
        {
            counter = 0;

            DecreaseTime();
            UpdateTime();
        }
    }

    private void DecreaseTime()
    {
        if (seconds == 0)
        {
            minutes--;
            seconds = 59;
        }
        else
        {
            seconds--;
        }

        if (minutes == 0 && seconds == 0)
        {
            GameManager.instance.Lose();
        }
    }

    private void UpdateTime()
    {
        timerText.text = minutes + ":" + (seconds < 10 ? "0" + seconds : seconds.ToString());
    }
}
