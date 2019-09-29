using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string username = GameControl.control.username;

        string message = "WELCOME";
        message += "\n" + username;
        message += "\n" + "----------------";
        GameObject.Find("Name").GetComponent<Text>().text = message;
        Debug.Log(message);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
