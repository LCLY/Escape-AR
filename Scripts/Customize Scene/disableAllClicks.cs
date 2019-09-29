using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableAllClicks : MonoBehaviour
{
    public bool disableClick = false;
    public bool doneCustomizeMode = false;
    public GameObject inventoryPanel;
    public GameObject tapInstruction;
    public GameObject itemMenuPanel;
    public GameObject victoryMessagePanel;
    public GameObject passwordPanel;
    public GameObject inputPanel;
    public GameObject solvedMessagePanel;
    // Start is called before the first frame update
    void Start()
    {
        disableClick = true;
        inventoryPanel.SetActive(false);
        tapInstruction.SetActive(false);
        itemMenuPanel.SetActive(false);
    }

    //In done button
    public void revealInventoryTapInstruction()
    {
        doneCustomizeMode = true; //already done customizing
        tapInstruction.SetActive(true);
        disableClick = false; //to enable all clicks
    }
}
