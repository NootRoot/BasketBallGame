using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject button;
    public GameObject timer;
    public GameObject score;
    private bool wait; //makes the controller wait one frame before beginning function

    // Start is called before the first frame update
    void Start()
    {
        wait = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
            //if the button is pressed and the timer isnt already running start the timer
            if (button.GetComponent<Button1>().Pressed && !timer.GetComponent<Timer>().isTimerRunning())
            {
                timer.GetComponent<Timer>().startTimer();
                score.GetComponent<Score>().reset_score();
            }
        }
        else
        {
            wait = false;
        }
        
    }
}
