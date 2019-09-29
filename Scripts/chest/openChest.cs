using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChest : MonoBehaviour
{
    public GameObject chestObj;
    bool isOpen = false;    
    bool hasPlayed = false;
    public GameObject keyObj;
    Animator keyAnimation;
  
    void Start()
    { 
        keyAnimation = keyObj.GetComponent<Animator>();       
        keyObj.SetActive(false);
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
                if (obj.name == "Chest" && isOpen == false)
                {
                    keyObj.SetActive(true);
                    keyAnimation.SetTrigger("keyUnlock");                 
                    isOpen = true;//so that it wont repeat again                              
                }
            }
        }
    }

}
