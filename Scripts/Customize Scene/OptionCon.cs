using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionCon : MonoBehaviour
{
    CustomizationPanel cstPan;
    CameraView cameraScript;
    Animator tableDrawer;   
    Animator drawerAnimator;
    public GameObject gameMessagePanel;
    // Start is called before the first frame update
    void Start()
    {
        cstPan = GameObject.Find("CustomizationPanel").GetComponent<CustomizationPanel>();
        cameraScript = GameObject.Find("CustomizationPanel").GetComponent<CameraView>();
        tableDrawer = GameObject.Find("Table").GetComponent<Animator>();      
        drawerAnimator = GameObject.Find("Chest of drawers").GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        transform.parent.gameObject.SetActive(false);
        RectTransform rt1 = transform.parent.parent.parent.parent.GetComponent<RectTransform>();
        RectTransform rt2 = transform.parent.parent.parent.GetComponent<RectTransform>();
        rt1.anchorMax = new Vector2(rt1.anchorMax.x, 0.8f);
        rt1.offsetMax = new Vector2(rt1.offsetMax.x, 0);
        rt2.anchorMax = new Vector2(rt2.anchorMax.x, 1.0f);
        rt2.offsetMax = new Vector2(rt2.offsetMax.x, 0);
        if (transform.parent.parent.name == "Hints")
        {
            cstPan.msgPan.SetActive(true);
            string message = "Enter your preferred " + gameObject.GetComponentInChildren<Text>().text + " message";
            message += "\n" + "To preview, click on the Hints button in the Menu";
            GameObject.Find("MessageInputPanel/Text").GetComponent<Text>().text = message;
            GameObject.Find("MessageInputPanel").GetComponent<InputPanelCon>().msg = gameObject.GetComponentInChildren<Text>().text;
        }

        if (cameraScript.tableDrawerOpened == true)
        {
            cameraScript.tableDrawerOpened = false; //because its closed
            tableDrawer.SetTrigger("closeTable3");          
        }

        if(cameraScript.handleDrawerOpened == true)
        {
            cameraScript.handleDrawerOpened = false;
            drawerAnimator.SetTrigger("closeHandle");            
        }

       
        if (cameraScript.chestOpened == true)
        {                       
            if (string.Equals(gameObject.GetComponentInChildren<Text>().text, "Default Item") || string.Equals(gameObject.GetComponentInChildren<Text>().text ,"Item 1") || string.Equals(gameObject.GetComponentInChildren<Text>().text, "Item 2"))
            {
                //Debug.Log(string.Equals(gameObject.GetComponentInChildren<Text>().text, "Default Item") +" " + string.Equals(gameObject.GetComponentInChildren<Text>().text, "Item 1") + " " + string.Equals(gameObject.GetComponentInChildren<Text>().text, "Item 2"));
            }
            else
            {
                cameraScript.closeChest();
                cameraScript.chestOpened = false;
            }
        }

        if (string.Equals(gameObject.GetComponentInChildren<Text>().text, "Puzzle 1") || string.Equals(gameObject.GetComponentInChildren<Text>().text, "Puzzle 2"))
        {

        }
        else
        {
            if (cameraScript.solvedPanel1.activeInHierarchy)
            {
                cameraScript.solvedPanel1.SetActive(false);
            }
            //hide light1
            if (cameraScript.puzzle1Light.activeInHierarchy)
            {
                cameraScript.puzzle1Light.SetActive(false);
            }

            if (cameraScript.solvedPanel2.activeInHierarchy)
            {
                cameraScript.solvedPanel2.SetActive(false);
            }
            //hide light2
            if (cameraScript.puzzle2Light.activeInHierarchy)
            {
                cameraScript.puzzle2Light.SetActive(false);
            }

        }

        if (string.Equals(gameObject.GetComponentInChildren<Text>().text, "Background 1") || string.Equals(gameObject.GetComponentInChildren<Text>().text, "Background 2") || string.Equals(gameObject.GetComponentInChildren<Text>().text, "Background 3"))
        {

        }
        else
        {
            if (gameMessagePanel.activeInHierarchy)
            {
                gameMessagePanel.SetActive(false);
            }
        }

    }
}
