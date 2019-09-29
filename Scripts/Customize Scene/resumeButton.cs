using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeButton : MonoBehaviour
{
    disableAllClicks gameControllerScript;
    public GameObject inventoryPanel; 
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
