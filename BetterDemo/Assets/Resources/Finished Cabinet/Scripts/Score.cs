using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private string topline;//the top line of the text box
    private string score;//string score
    public int score_num;//integer score
    // Start is called before the first frame update
    void Start()
    {
        score_num = 0;
        topline = "Score:";
        score = score_num + "";

    }

    // Update is called once per frame
    void Update()
    {
        //score_num = ++score_num % 60;
        score = score_num + "";
        this.GetComponent<TextMesh>().text = topline + "\n" + score;
    }

    public void increment_score()
    {
        score_num++;
    }

    //Sets the score integer to 0
    public void reset_score()
    {
        score_num = 0;
    }
}
