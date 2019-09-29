using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
public class DeployRoom : MonoBehaviour
{
    public GameObject game;
    public GameObject groundPlane;
    public GameObject ARCamera;
    public GameObject Viewcamera;
    public GameObject customizePanelWrap;
    public GameObject customizePanelObj;
    public GameObject tapInstruction;
    public GameObject doneButton;
    public GameObject customTitle;
    public GameObject gameMessagePanel;
    public GameObject exitButton;

    CameraView cameraScript;
    disableAllClicks disableScript;

    public GameObject tableObj;
    public GameObject drawerObj;

    Animator openTable;
    Animator openDrawer;

    public GameObject spotlightKeyPos2;
    public GameObject pointLightKey1;
    public GameObject drawerSpotLight;
    public GameObject chestSpotlight;

    // Start is called before the first frame update
    void Start()
    {
        cameraScript = customizePanelObj.GetComponent<CameraView>();
        disableScript = GameObject.Find("Game Controller").GetComponent<disableAllClicks>();
        openTable = tableObj.GetComponent<Animator>();
        openDrawer = drawerObj.GetComponent<Animator>();
        //gameMessagePanel = GameObject.Find("GameMessagePanel");
    }

    // Update is called once per frame
    void Update()
    {

    }
    //this is called in done
    public void deploy()
    {
        if (cameraScript.handleDrawerOpened == true)
        {
            //if its opened, then close it
            openDrawer.SetTrigger("closeHandle");
        }

        if (cameraScript.tableDrawerOpened == true)
        {
            openTable.SetTrigger("closeTable3");
        }
        if (spotlightKeyPos2.activeInHierarchy)
        {
            //if the spotlight of key2 is activated, set it to false
            spotlightKeyPos2.SetActive(false);
        }

        if (pointLightKey1.activeInHierarchy)
        {
            pointLightKey1.SetActive(false);
        }

        if (drawerSpotLight.activeInHierarchy)
        {
            drawerSpotLight.SetActive(false);
        }

        if (chestSpotlight.activeInHierarchy)
        {
            chestSpotlight.SetActive(false);
        }

        if (cameraScript.chestOpened == true)
        {
            cameraScript.closeChest();
            cameraScript.chestOpened = false;
        }

        if (cameraScript.solvedPanel1.activeInHierarchy)
        {
            cameraScript.solvedPanel1.SetActive(false);
        }

        if (cameraScript.puzzle1Light.activeInHierarchy)
        {
            cameraScript.puzzle1Light.SetActive(false);
        }

        if (cameraScript.solvedPanel2.activeInHierarchy)
        {
            cameraScript.solvedPanel2.SetActive(false);
        }

        if (cameraScript.puzzle2Light.activeInHierarchy)
        {
            cameraScript.puzzle2Light.SetActive(false);
        }

        if (cameraScript.tableLight.activeInHierarchy)
        {
            cameraScript.tableLight.SetActive(false);
        }
          
        if(disableScript.victoryMessagePanel.activeInHierarchy){
            disableScript.victoryMessagePanel.SetActive(false);
        }

        if (disableScript.passwordPanel.activeInHierarchy)
        {
            disableScript.passwordPanel.SetActive(false);
        }

        if (disableScript.inputPanel.activeInHierarchy)
        {
            disableScript.inputPanel.SetActive(false);
        }

        if (disableScript.solvedMessagePanel.activeInHierarchy)
        {
            disableScript.solvedMessagePanel.SetActive(false);
        }

        if (gameMessagePanel.activeInHierarchy)
        {
            gameMessagePanel.SetActive(false);
        }

        if (exitButton.activeInHierarchy)
        {
            exitButton.SetActive(true);
        }

        var listenerBehaviour = GetComponent<AnchorInputListenerBehaviour>();
        if(listenerBehaviour != null && listenerBehaviour.enabled == false)
        {
            listenerBehaviour.enabled = true;
        }

        customizePanelWrap.SetActive(false); //customize panel should be hide after done because player already done customizing the room

        if(tapInstruction != null)
        {
            tapInstruction.SetActive(false);
        }

        doneButton.SetActive(false);
        customTitle.SetActive(false);

        //game.transform.parent = groundPlane.transform;
        ARCamera.SetActive(true);
        Viewcamera.SetActive(false);

        /* GameObject groundPlane = new GameObject();
         GameObject game = new GameObject();
         GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
         foreach (GameObject child in objects)
         {
             if (child.name == "ARCamera")
             {
                 child.SetActive(true);
             }
             else if (child.name == "View Camera 1")
             {
                 child.SetActive(false);
             }
             else if(child.name == "Ground Plane Stage")
             {
                 groundPlane = child;
             }
             else if(child.name == "Game")
             {
                 game = child;
             }
         }*/
        
        //game.transform.parent = null;
        game.transform.SetParent(groundPlane.transform, false);
        foreach(Transform child in game.transform)
        {
            //child.gameObject.SetActive(false);
            //child.gameObject.GetComponent<Renderer>().enabled = false;
            unrenderChild(child.transform);
        }
        //game.SetActive(false);


        print("done deploy");
    }
    
    public static void unrenderChild(Transform t) 
    {
        if (t.childCount > 0)
        {
            foreach (Transform child in t)
            {
                unrenderChild(child);
            }
        }
        if(t.gameObject.GetComponent<Renderer>() != null)
        {
            t.gameObject.GetComponent<Renderer>().enabled = false;
        }
        else if (t.gameObject.GetComponent<Text>() != null)
        {
            t.gameObject.SetActive(false);
        }
        else if (t.gameObject.GetComponent<TextMeshProUGUI>() != null)
        {
            t.gameObject.SetActive(false);
        }
    }
    public static void renderChild(Transform t)
    {
        if (t.childCount > 0)
        {
            foreach (Transform child in t)
            {
                renderChild(child);
            }
        }
        if (t.gameObject.GetComponent<Renderer>() != null)
        {
            t.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if(t.gameObject.GetComponent<Text>() != null)
        {
            t.gameObject.SetActive(true);
        }
        else if (t.gameObject.GetComponent<TextMeshProUGUI>() != null)
        {
            t.gameObject.SetActive(true);
        }
    }
}
