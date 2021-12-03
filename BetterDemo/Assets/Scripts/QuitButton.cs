using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    private bool b = false;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        b = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (b)
        {
            //Debug.LogError("AAAAA");
            //        x = x + 200;
            //launcher.transform.position = new Vector3(0, 0, 0);
            gameManager.GetComponent<GameManager>().LeaveRoom();
        }

        //        launcher.transform.position.x = launcher.transform.position.x + 200;
        //        launcher.GetComponent<Transform>().position.x= launcher.GetComponent<Transform>().position.x+200;//.Connect();
    }
}
