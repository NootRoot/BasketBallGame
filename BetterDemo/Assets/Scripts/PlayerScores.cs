using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Timers;

public class PlayerScores : MonoBehaviourPunCallbacks, IPunObservable
{
    private string scoreBoard;//score to display for user
    private Dictionary<string,string> playerScores = new Dictionary<string,string>();
    [SerializeField]
    public string myScore; //score to send to others
    //public Sequencer sequencer;
    public string incomingScore;
    public Score scorer;
    private string topline;
    //private static System.Timers.Timer aTimer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started");
        scoreBoard = "";
        myScore = "";
        incomingScore = "";
        topline = scoreBoard;
        //var rand = new System.Random();
        //aTimer = new System.Timers.Timer(rand.Next(1000, 6001));
        //aTimer.Enabled = true;
        //aTimer.Elapsed += OnTimedEvent;
    }

    // Update is called once per frame
    void Update()
    {
        topline = "Scores:\nYou: " + scorer.score_num + "\n";
        //if (Assigner.assignment != 0)
        //{
        myScore = "Player Other: " + scorer.score_num;
            //myScore = "Player " + Assigner.assignment + ": " + scorer.score_num;
        //}
        this.GetComponent<TextMesh>().text = topline + scoreBoard;
    }

    #region IPunObservable implementation


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("serializing");
        if (stream.IsWriting)
        {
            stream.SendNext(myScore);
        }
        else
        {
            incomingScore = (string)stream.ReceiveNext();
            if (incomingScore == "")
            {
                incomingScore = "nothing";
            }
            /*if (incomingScore != "")
            {
                if (playerScores.ContainsKey(incomingScore.Substring(0, incomingScore.IndexOf(":") + 1))) //if we have heard of this player before
                {
                    playerScores[incomingScore.Substring(0, incomingScore.IndexOf(":") + 1)] = incomingScore;
                }
                Dictionary<string, string>.ValueCollection valueColl = playerScores.Values;
                string board = "";//"Scores:\nYou: "+scorer.score_num+"\n";
                foreach (string s in valueColl)
                {
                    board = board + s + "\n";
                }*/
                scoreBoard = incomingScore;
            //}
        }
    }


#endregion


    private static void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        //Assigner.assign();
    }
}
