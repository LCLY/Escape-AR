using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonClip : MonoBehaviour
{
    AudioSource buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        buttonSound = GameObject.Find("buttonClickAudio").GetComponent<AudioSource>();
    }

    public void playSound()
    {
        buttonSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
