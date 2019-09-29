using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUseFunc : MonoBehaviour
{
    //THE SCRIPT IS IN CHEST
    public bool isOpen;
    public GameObject keyObj;
    public GameObject puzzle;
    Animator keyAnimation;
    AudioSource keySound;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;        
        //the animation of chest being opened is trigger in keyAnimationTrigger.cs - triggerAnimation() function by an animation event
        keyAnimation = keyObj.GetComponent<Animator>();
        keyObj.SetActive(false); // the key should be hidden before the animation happens.
        keySound = keyObj.GetComponent<AudioSource>();


    }

    public int UseIt()
    {
        if (isOpen == false)
        {
            isOpen = true;
            //play the key animation and then chest animation and chest audio will be played in the animation event function trigger
            keyObj.SetActive(true);
            keyAnimation.SetTrigger("keyUnlock");     
            keySound.Play();
            puzzle.transform.GetComponent<PuzzleTracker>().isSolved = true;
            UpdatePuzzleNumber.remainingPuzzleNum -= 1;
            UpdatePuzzleNumber.UpdateRemainingPuzzleNumText();
            return 0;
        }
        else
        {
            return 1;
        }
        
    }
}
