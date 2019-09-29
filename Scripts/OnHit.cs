using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class OnHit : MonoBehaviour
{
    public GameObject tapInstruction;
    public GameObject inventoryPanel; 
    public GameObject defaultPlaneIndicator;
    public GameObject game;
    public bool roomIsDeployed;
    public GameObject ARCamera;
    public GameObject moveLocation;
    Vector3 oriPos;
    // Start is called before the first frame update
    void Start()
    {
        if(inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
        roomIsDeployed = false;

        oriPos = moveLocation.transform.position;
    }

    // Update is called once per frame
    void Update()
    {      
    }

    public void OnInteractiveHitTest(HitTestResult result)
    {
        var listenerBehaviour = GetComponent<AnchorInputListenerBehaviour>();
        tapInstruction.SetActive(false);

        if (listenerBehaviour != null)
        {
            GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject obj in objects)
            {

                if (obj.name == "DefaultPlaneIndicator(Clone)")
                {
                    foreach (Transform child in obj.transform)
                    {
                        child.gameObject.SetActive(false);
                    }

                    print("remove plane indicator");
                    break;
                }
            }


            listenerBehaviour.enabled = false;
            GameObject tv = GameObject.FindWithTag("TV");
            var videoPlayer = tv.GetComponent<VideoPlayer>();
            videoPlayer.Play();
            inventoryPanel.SetActive(true);//reveal the inventory panel          
            defaultPlaneIndicator.SetActive(false);
            roomIsDeployed = true;
            //move the AR camera into the game object
            //EXPERIMENTAL PURPOSE!!!
            ARCamera.transform.SetParent(game.transform, false);
            ARCamera.transform.position = oriPos;
        }
    }
    public void OnInteractiveHitTestForCustomize(HitTestResult result)
    {
        var listenerBehaviour = GetComponent<AnchorInputListenerBehaviour>();
        tapInstruction.SetActive(false);
        if (listenerBehaviour != null)
        {

            GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject obj in objects)
            {

                if (obj.name == "DefaultPlaneIndicator(Clone)")
                {
                    foreach (Transform child in obj.transform)
                    {
                        child.gameObject.SetActive(false);
                    }

                    print("remove plane indicator");
                    break;
                }
            }

            foreach (Transform child in game.transform)
            {
                //child.gameObject.GetComponent<Renderer>().enabled = true;
                DeployRoom.renderChild(child.transform);
            }


            listenerBehaviour.enabled = false;
            GameObject tv = GameObject.FindWithTag("TV");
            var videoPlayer = tv.GetComponent<VideoPlayer>();
            videoPlayer.Play();
            inventoryPanel.SetActive(true);//reveal the inventory panel           
            defaultPlaneIndicator.SetActive(false); // should hide the plane finder
            roomIsDeployed = true;
            //move the AR camera into the game object
            //EXPERIMENTAL PURPOSE!!!
            ARCamera.transform.SetParent(game.transform, false);
            ARCamera.transform.position = oriPos;
        }
    }
}
