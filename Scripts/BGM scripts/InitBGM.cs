using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBGM : MonoBehaviour
{
    private GameControl control;
    private AudioSource bgm;
    void Start()
    {
        control = GameControl.control;
        control.Load();
        bgm = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        if (control.bgm == true)
        {
            bgm.Play();
        }
        else
        {
            bgm.Stop();
        }
    }
}
