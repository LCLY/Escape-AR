using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    public void MusicToggle(GameObject target)
    {
        bool sw = GetComponent<Toggle>().isOn;
        if (sw)
        {
            target.GetComponent<AudioSource>().Play();
        }
        else
        {
            target.GetComponent<AudioSource>().Stop();
        }
    }
}
