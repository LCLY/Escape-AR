using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test1 : MonoBehaviour
{
    public GameObject[] test;
    public bool startstate;
    public AudioSource AS;
    Toggle tg;
    // Start is called before the first frame update
    void Start()
    {
        if (GameControl.control.bgm == false)
        {
            startstate = false;
        } else
        {
            startstate = true;
            GameControl.control.bgm = true;
        }
        
        tg.isOn = startstate;
        tg.onValueChanged.AddListener(delegate
        {
            VChanged(tg);
        });
        if (tg.isOn)
        {
            AS.Play();
        }
        else
        {
            AS.Stop();
        }
    }

    // Update is called once per frame
    void VChanged(Toggle tg) 
    {
        if (tg.isOn) AS.Play(); else AS.Stop();
    }
}
