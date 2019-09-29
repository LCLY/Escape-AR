using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableDrawerGameMode : MonoBehaviour
{
    Animator tableAnimator;
    AudioSource openDrawer;
    bool hasPlayed1 = false;
    bool hasPlayed2 = false;
    bool hasPlayed3 = false;
    // Start is called before the first frame update
    void Start()
    {
        tableAnimator = GetComponent<Animator>();
        openDrawer = GetComponent<AudioSource>();      
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

                    //checking sthe hit object name and also the boolean value whether it is already combined or not
                    if (obj.name == "Object001")
                    {
                        tableAnimator.SetTrigger("table1");
                        if (hasPlayed1 == false)
                        {
                            openDrawer.Play();
                            hasPlayed1 = true;
                        }
                    }

                    if (obj.name == "Object002")
                    {
                        tableAnimator.SetTrigger("table2");
                        if (hasPlayed2 == false)
                        {
                            openDrawer.Play();
                            hasPlayed2 = true;
                        }
                    }

                    if (obj.name == "Object003")
                    {
                        tableAnimator.SetTrigger("table3");
                        if (hasPlayed3 == false)
                        {
                            openDrawer.Play();
                            hasPlayed3 = true;
                        }
                    }
                }
            
        }      
    }
}
