using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    public float endstop;//how far down you want the button to be pressed before it triggers
    public bool Pressed = false;
    //public GameObject stopper;

    private Vector3 StartPos;
    //private bool ReverseDirection = false;
    //private int Frames_until_button_reset = 8;
    //private int Current_num_frames_since_pressed;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        //Current_num_frames_since_pressed = Frames_until_button_reset;

    }
    void Update()
    {

        //Transform stopper = GameObject.Find("Button Stop").transform;

        if (transform.position.z - StartPos.z > 0.05f)
        {//check to see if the button has been pressed all the way down

            //transform.position = StartPos;
            transform.position = new Vector3(StartPos.x, StartPos.y, StartPos.z+0.05f);

            //GameObject.FindGameObjectWithTag("PressableButton").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Pressed = true;//update pressed
        }

        //un press the button
        if (Pressed && transform.position.z - StartPos.z < 0.048f)
        {
            Pressed = false;
        }

        if (transform.position.z < StartPos.z)
        {
            transform.position = StartPos;
            //GameObject.FindGameObjectWithTag("PressableButton").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        /*
        void OnCollisionExit(Collision collision)//check for when to unlock the button
        {
            Debug.Log("unlock");
            if (collision.gameObject.tag == "Hand")
            {
                // GetComponent().constraints &= ~RigidbodyConstraints.FreezePositionY; //Remove Y movement constraint.
                Pressed = false;//update pressed
            }
        }
        */
    }

}
