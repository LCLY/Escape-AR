using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectCon : MonoBehaviour
{
    CustomizationPanel cstPan;
    disableAllClicks disableScript; //to access victorymessage panel
    public GameObject passwordPanel;
    CameraView cameraScript;  
    // Start is called before the first frame update
    void Start()
    {
        cstPan = GameObject.Find("CustomizationPanel").GetComponent<CustomizationPanel>();
        disableScript = GameObject.Find("Game Controller").GetComponent<disableAllClicks>();
        cameraScript = GameObject.Find("CustomizationPanel").GetComponent<CameraView>();      
    }

    // Update is called once per frame
        void Update()
    {
        
    }

    public void OnMouseDown()
    {
        GameObject list = transform.Find("List").gameObject;
        list.SetActive(!list.activeSelf);

        if (!list.activeSelf)
        {
            RectTransform rt1 = transform.parent.parent.GetComponent<RectTransform>();
            RectTransform rt2 = transform.parent.GetComponent<RectTransform>();
            rt1.anchorMax = new Vector2(rt1.anchorMax.x, 0.8f);
            rt1.offsetMax = new Vector2(rt1.offsetMax.x, 0);
            rt2.anchorMax = new Vector2(rt2.anchorMax.x, 1.0f);
            rt2.offsetMax = new Vector2(rt2.offsetMax.x, 0);
        }
        else
        {
            RectTransform rt1 = transform.parent.parent.GetComponent<RectTransform>();
            RectTransform rt2 = transform.parent.GetComponent<RectTransform>();
            rt1.anchorMax = new Vector2(rt1.anchorMax.x, 6.2f);
            rt1.offsetMax = new Vector2(rt1.offsetMax.x, 0);
            rt2.anchorMax = new Vector2(rt2.anchorMax.x, 0.1f);
            rt2.offsetMax = new Vector2(rt2.offsetMax.x, 0);
        }
        

        
        foreach (Transform child in transform.parent)
        {
            if (child != transform)
            {
                child.Find("List").gameObject.SetActive(false);
            }
        }
        if(cstPan.msgPan.activeInHierarchy)
        {
            cstPan.msgPan.SetActive(false);
        }

        if (disableScript.victoryMessagePanel.activeInHierarchy)
        {
            disableScript.victoryMessagePanel.SetActive(false);         
        }

        if (disableScript.solvedMessagePanel.activeInHierarchy)
        {
            disableScript.solvedMessagePanel.SetActive(false);           
        }

        if(cameraScript.inSolvedPanel1 == true)
        {
            cameraScript.inSolvedPanel1 = false;
        }

        if (cameraScript.inSolvedPanel2 == true)
        {
            cameraScript.inSolvedPanel2 = false;
        }
      

        passwordPanel.SetActive(false);
    }
}
