using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBGM : MonoBehaviour
{
    private Text txt;
    private GameControl control;
    private AudioSource bgm;
    void Start()
    {
        txt = GetComponent<Button>().transform.Find("Text").GetComponent<Text>();
        control = GameControl.control;
        bgm = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        control.Load();
        if (control.bgm == false)
        {
            txt.text = "BGM Off";
            bgm.Stop();
        }
        else
        {
            if (!bgm.isPlaying)
            {
                bgm.Play();
            }
            txt.text = "BGM On";
            control.bgm = true;
            control.Save();
        }
    }

    public void TurnOnOff()
    {
        if (control.bgm == true)
        {
            control.bgm = false;
            control.Save();
            txt.text = "BGM Off";
            bgm.Stop();
        } else
        {
            control.bgm = true;
            control.Save();
            txt.text = "BGM On";
            bgm.Play();
        }
    }
}
