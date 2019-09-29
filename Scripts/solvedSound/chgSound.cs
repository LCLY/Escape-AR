using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chgSound : MonoBehaviour
{
    public GameObject chest;
    public GameObject drawer;
    AudioSource audioSource;
    AudioSource audioSource2;
    AudioSource audioManager;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip ori;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = chest.GetComponent<AudioSource>();
        audioSource2 = drawer.GetComponent<AudioSource>();
        audioManager = GetComponent<AudioSource>();
    }

    public void ChangeClip1()
    {
        audioSource.clip = clip1;
        audioSource2.clip = clip1;
        Debug.Log("Changed to Clip1");
        audioManager.clip = clip1;
        audioManager.Play();
    }

    public void ChangeClip2()
    {
        audioSource.clip = clip2;
        audioSource2.clip = clip2;
        Debug.Log("Changed to Clip2");
        audioManager.clip = clip2;
        audioManager.Play();
    }

    public void ChangeClip3()
    {
        audioSource.clip = clip3;
        audioSource2.clip = clip3;
        Debug.Log("Changed to Clip3");
        audioManager.clip = clip3;
        audioManager.Play();
    }

    public void ChangeOri()
    {
        audioSource.clip = ori;
        audioSource2.clip = ori;
        Debug.Log("Changed to Ori");
        audioManager.clip = ori;
        audioManager.Play();
    }
}
