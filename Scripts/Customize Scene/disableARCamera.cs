using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableARCamera : MonoBehaviour
{
    public GameObject ARCamera;  
    public GameObject viewCamera1;    
    
    // Start is called before the first frame update
    void Start()
    {       
        ARCamera.SetActive(false);       
        viewCamera1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {      
       
    }
}
