using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using Photon.Realtime;
using Photon.Pun;
using System;

public class Assigner : MonoBehaviour, IPunObservable
{
    public static int message = 0;
    private static System.Timers.Timer aTimer;
    public static int assignment = 0;
    public static ArrayList al = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void assign()
    {
        var rand = new System.Random();
        int attempts = 150;
        int i = rand.Next(51);
        while (al.Contains(i) && attempts > 0)
        {
            i = rand.Next(51);
            attempts--;
        }
        if (attempts == 0)
        {
            assignment = -1;
        }
        assignment = i;
    }

    #region IPunObservable implementation

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(assignment);
        }
        else
        {
            message = (int)stream.ReceiveNext();
            if (message == assignment)
            {
                var rand = new System.Random();
                aTimer = new System.Timers.Timer(rand.Next(1000,6001));
                aTimer.Enabled = true;
                aTimer.Elapsed += OnTimedEvent;
            }
        }
    }


    #endregion

    private static void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        assign();
    }
}
