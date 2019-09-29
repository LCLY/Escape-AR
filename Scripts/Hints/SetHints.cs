using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHints : MonoBehaviour
{
    public bool isCustom;

    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;
    public GameObject hintButtonTextObj;

    public static int hintCount = 3;
    public static int currentHints = 0;
    public string[] hints = new string[9];

    // Start is called before the first frame update
    void Start()
    {

    }

    public void resetHints()
    {
        hintCount = 3;
        currentHints = 0;
        hintButtonTextObj.GetComponent<Text>().text = "Hints (3/3)";
    }

}
