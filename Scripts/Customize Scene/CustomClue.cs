using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomClue : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject newPasscodeTextObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateClue()
    {
        //Grab passcode from player's customization
        string passcode = newPasscodeTextObj.GetComponent<Text>().text;

        //Clue to be written on block
        string[] clueNum = new string[] {"ZEROX","ONEXX","TWOXX","THREE","FOURX","FIVEX","SIXXX","SEVEN","EIGHT","NINEX"};

        //Block text color sequence
        string[] canvasColor = new string[] {"CanvasRed","CanvasBlue","CanvasYellow","CanvasGreen"};
        string[] blockColor = new string[] { "BlockRed", "BlockBlue", "BlockYellow", "BlockGreen"};

        for (int i = 0; i < 4; i++) {
            int passcodeDigit = passcode[i] - '0';
            for (int j = 0; j < blocks.Length; j++) {
                char blockChar = clueNum[passcodeDigit][j];
                blocks[j].transform.Find(canvasColor[i]).transform.Find(blockColor[i]).GetComponent<Text>().text = blockChar.ToString();
            }
        }
    }
}
