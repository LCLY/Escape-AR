using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeButtonForCustomize : MonoBehaviour
{
    disableAllClicks gameControllerScript;
    public GameObject inventoryPanel;
    public GameObject customizePanel;
    public GameObject onHitObj;
    OnHit onhitScript;
    // Start is called before the first frame update
    void Start()
    {
        gameControllerScript = GameObject.Find("Game Controller").GetComponent<disableAllClicks>();
        onhitScript = onHitObj.GetComponent<OnHit>();
    }

    public void showPanelAccordingly()
    {
        //only after the user pressed done button and after deploying the room, then the resume button will show the inventory panel 
        if (gameControllerScript.doneCustomizeMode == true && onhitScript.roomIsDeployed == true)
        {
            inventoryPanel.SetActive(true);
        }
        else if(gameControllerScript.doneCustomizeMode == false) //if the customization mode is not done yet, user should still see the customization panel
        {
            customizePanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
