using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class solvedMessage : MonoBehaviour
{
    public GameObject solvedCanvas;   

    CameraView cameraScript;
    public GameObject solvedTextObj;
    Text solvedText;

    //solved panel 1
    public GameObject chestTextObj;
    Text chestText;

    //solved panel 2
    public GameObject drawerTextObj;
    Text drawerText;

    public InputField solvedInputField;

    public Slider slider_R_1;
    public Slider slider_G_1;
    public Slider slider_B_1;

    public Slider slider_R_2;
    public Slider slider_G_2;
    public Slider slider_B_2;

    // Start is called before the first frame update
    void Start()
    {
        cameraScript = GameObject.Find("CustomizationPanel").GetComponent<CameraView>();
        solvedText = solvedTextObj.GetComponent<Text>();
        chestText = chestTextObj.GetComponent<Text>();
        drawerText = drawerTextObj.GetComponent<Text>();
        slider_R_1.value = 1;
        slider_G_1.value = 1;
        slider_B_1.value = 1;

        slider_R_2.value = 1;
        slider_G_2.value = 1;
        slider_B_2.value = 1;
    }

    public void submitSolvedMessage()
    {
        if(cameraScript.inSolvedPanel1 == true)
        {           
            solvedCanvas.SetActive(false);
            cameraScript.inSolvedPanel1 = false;
            if(solvedInputField.text == "" && !string.IsNullOrEmpty(chestText.text))
            {
                //shouldnt change text
            }
            else
            {
                chestText.text = solvedText.text; //change text       
            }
            chestText.color = new Color(slider_R_1.value, slider_G_1.value, slider_B_1.value);          
        }
        else if(cameraScript.inSolvedPanel2 == true)
        {          
            solvedCanvas.SetActive(false);
            cameraScript.inSolvedPanel2 = false;
            if (solvedInputField.text == "" && !string.IsNullOrEmpty(drawerText.text))
            {
                //shouldnt change text
            }
            else
            {
                drawerText.text = solvedText.text;
            }

            drawerText.color = new Color(slider_R_2.value, slider_G_2.value, slider_B_2.value);          
        }            

        solvedInputField.text = "";      
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraScript.inSolvedPanel1 == true)
        {
            chestText.color = new Color(slider_R_1.value, slider_G_1.value, slider_B_1.value);
        }else if(cameraScript.inSolvedPanel2 == true)
        {
            drawerText.color = new Color(slider_R_2.value, slider_G_2.value, slider_B_2.value);
        }


    }
}