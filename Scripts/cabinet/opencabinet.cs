using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencabinet : MonoBehaviour
{
    public GameObject cupboardObj;
    Animator openCabinet;
    AudioSource openSound;
    public GameObject gameController;
    disableAllClicks disableScript;
    bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        openCabinet = cupboardObj.GetComponent<Animator>();
        openSound = GetComponent<AudioSource>();
        disableScript = gameController.GetComponent<disableAllClicks>();
    }
     

    // Update is called once per frame
    void Update()
    {     
        if(disableScript.disableClick == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject obj = hit.collider.gameObject;
                    //Debug.Log("obj: " + obj.name);
                    if (obj.name == "mirror")
                    {
                        openCabinet.SetTrigger("openMirror"); //play the animation
                        if (hasPlayed == false)
                        {
                            //if its already played then it will not be played again
                            openSound.Play();
                            hasPlayed = true;
                        }

                        Debug.Log("animation: " + openCabinet);
                    }
                }
            }
        }              
    }
}

