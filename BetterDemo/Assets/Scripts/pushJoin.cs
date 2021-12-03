using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushJoin : MonoBehaviour
{
    public GameObject launcher;
    private bool b = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("Hello");
        //x = launcher.transform.position.x;
        //launcher = new Launcher();
        b = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (b) {
            //Debug.LogError("AAAAA");
            //        x = x + 200;
            //launcher.transform.position = new Vector3(0, 0, 0);
            launcher.GetComponent<Launcher>().Connect();
        }

//        launcher.transform.position.x = launcher.transform.position.x + 200;
//        launcher.GetComponent<Transform>().position.x= launcher.GetComponent<Transform>().position.x+200;//.Connect();
    }
}
