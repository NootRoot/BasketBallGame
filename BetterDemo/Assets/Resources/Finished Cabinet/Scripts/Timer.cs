using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private string topline;//the first line of the timer text
    private string timer;//the second line of the timer text
    private int timer_num;//the current second the timer is at
    private bool isRunning;//whether the timer is currently counting down or not
    private const int MAX_TIME = 40; //the amount of time the player has to score points (in seconds)
    private const int FLASH_FRAMES = 60; //the number of frames between each flash when the timer runs out
    private const int MAX_NUM_FLASHES = 5; //the number of times the text will flash when the timer runs out
    private int times_flashed; //the number of times the text has flashed
    private int frames_passed; //the number of frames since the last flash

    private System.DateTime startTime;//the time the timer was started

    // Start is called before the first frame update
    void Start()
    {
        timer_num = 0;
        topline = "Time:";
        timer = timer_num + "";
        isRunning = false;
        times_flashed = 0;
        this.GetComponent<TextMesh>().text = topline + "\n" + timer;
    }

    // Update is called once per frame
    void Update()
    {
        //only update if the timer is running
        if (isRunning) {
            //update the seconds left
            System.DateTime currentTime = System.DateTime.Now;
            System.TimeSpan changeInTime = currentTime.Subtract(startTime);
            timer_num = MAX_TIME - (int)changeInTime.TotalSeconds; //time - delta time makes the timer count down

            //if timer is over flash three times and reset to 0
            //otherwise update the text normally
            if (timer_num <= 0)
            {
                //if the timer has flashed max times reset the timer
                if(times_flashed == MAX_NUM_FLASHES)
                {
                    this.reset();
                }
                else//add to frames passed and update text accordingly
                {
                    /**
                     *FLASH FRAMES is for an entire wavelength (off and on)
                     *the first half of FLASH FRAMES the text will be visible
                     *the second half of FLASH FRAMES the text will be invisible
                     */
                    ++frames_passed;
                    if(frames_passed%FLASH_FRAMES <= FLASH_FRAMES / 2)
                    {
                        timer = "0";
                    }
                    else
                    {
                        timer = "";
                    }
                    //if frames passed goes through an entire wavelength, add to times flashed
                    if(frames_passed%FLASH_FRAMES == 0)
                    {
                        times_flashed++;
                    }
                }
            }
            else
            {
                //update the timer text normally
                timer = timer_num + "";
            }
        }

        //actually update the text
        this.GetComponent<TextMesh>().text = topline + "\n" + timer;

    }

    //This will start the timer which will count down from STARTING_TIME
    public void startTimer()
    {
       startTime = System.DateTime.Now;
       isRunning = true;
    }

    private void reset()
    {
        isRunning = false;
        times_flashed = 0;
        timer_num = 0;
        frames_passed = 0;
    }

    //returns true if timer is currently counting down and false otherwise
    public bool isTimerRunning()
    {
        return this.isRunning;
    }
}
