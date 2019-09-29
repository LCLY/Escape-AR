using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metronomeScript : MonoBehaviour
{
    AudioSource metronomeAudio;
    Animator metronomeAnimator;
    bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        metronomeAudio = GetComponent<AudioSource>();
        metronomeAnimator = GetComponent<Animator>();
    }

    public void resetHasPlayed()
    {
        hasPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                //Debug.Log("obj: " + obj.name);
                if (obj.name == "metroCollider")
                {
                    if(hasPlayed == false)
                    {
                        metronomeAudio.Play();
                        hasPlayed = true;
                    }
                   
                    metronomeAnimator.SetTrigger("startMetronome");                                       
                }
            }
        }
    }
}
