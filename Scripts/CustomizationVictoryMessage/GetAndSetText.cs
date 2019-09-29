using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAndSetText : MonoBehaviour
{
    public InputField msg;
    public Text ftext;
    public GameObject pan;


    public void setget()
    {
        Debug.Log("Im called and msg = "+msg.text);
        
        ftext.text = ""+msg.text;
        
    }

    public void setFalse()
    {
        pan.SetActive(false);
    }
}
