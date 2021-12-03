using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Detector : MonoBehaviour
{
    public GameObject timer;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer.GetComponent<Timer>().isTimerRunning())
        {
            score.GetComponent<Score>().increment_score();
        }
    }
}
