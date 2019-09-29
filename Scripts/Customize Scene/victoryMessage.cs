using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victoryMessage : MonoBehaviour
{
    public GameObject messageInputPanel;
    public GameObject List;
    public GameObject gameMessagePanel;
    //public GameObject inputTextObj;
    //Text inputText;
    // Start is called before the first frame update

    void Start()
    {
        //inputText = inputTextObj.GetComponent<Text>();
    }
    public void revealInputMessagePanel()
    {
        gameMessagePanel.SetActive(true);
        messageInputPanel.SetActive(true);
        
        //inputText.text = "Enter your preferred victory message";
    }

    public void listFalse()
    {
        List.SetActive(false);
    }
}
