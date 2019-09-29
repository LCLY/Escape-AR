using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerAnimation : MonoBehaviour
{
    //THIS SCRIPT IS IN DRAWER
    Animator drawerAnimator;
    AudioSource openDrawerAudio;
    RevealHandle revealHandleScript;
    bool hasPlayed1 = false; //boolean value to make sure that the audio wont keep playing if the player spam clicking
    bool hasPlayed2 = false;
    bool hasPlayed3 = false;
    public static UpdatePuzzleNumber remainingPuzzle;
    //canvas obj
    public GameObject canvasObj;

    //puzzle object
    public GameObject puzzle;

    // Start is called before the first frame update
    void Start()
    {
        canvasObj.SetActive(false);
        //getting all the component from the drawer parent object
        drawerAnimator = GetComponent<Animator>();
        openDrawerAudio = GetComponent<AudioSource>();
        revealHandleScript = GetComponent<RevealHandle>();
        remainingPuzzle = new UpdatePuzzleNumber();
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
                //Debug.Log("Object name: " + obj.name);
              
                //checking the hit object name and also the boolean value whether it is already combined or not
                if (obj.name == "Drawer_Med1" && revealHandleScript.handle1Combined == true)
                {
                    if(hasPlayed1 == false)
                    {
                        drawerAnimator.SetTrigger("handle1");
                        openDrawerAudio.Play();
                        hasPlayed1 = true;
                    }
                }
                if(obj.name == "Drawer_Med2" && revealHandleScript.handle2Combined == true)
                {
                    if (hasPlayed2 == false)
                    {
                        drawerAnimator.SetTrigger("handle2");
                        openDrawerAudio.Play();
                        hasPlayed2 = true;
                        puzzle.transform.GetComponent<PuzzleTracker>().isSolved = true;
                        UpdatePuzzleNumber.remainingPuzzleNum -= 1;
                        UpdatePuzzleNumber.UpdateRemainingPuzzleNumText();
                    }
                }
                if(obj.name == "Drawer_Big2" && revealHandleScript.handle3Combined == true)
                {
                    if (hasPlayed3 == false)
                    {
                        drawerAnimator.SetTrigger("handle3");
                        openDrawerAudio.Play();
                        hasPlayed3 = true;
                    }
                }
            }
        }

    }

    public void ControlPanel()
    {
        canvasObj.SetActive(true);
        Invoke("DeactivateMsgPanel", 4.5f);
    }

    void DeactivateMsgPanel()
    {
        canvasObj.SetActive(false);
    }
}
