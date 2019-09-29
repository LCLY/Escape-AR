using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAndHide : MonoBehaviour
{
    public GameObject[] toshow;
    public GameObject[] tohide;
   
    public void TakeEffect()
    {
        //if user already completed customization mode, then the inventory panel should be set active instead     

        foreach (GameObject g in toshow)
        {
          
            g.SetActive(true);
            
            if (g.name == "HintsPanel")
            {
                if (g.transform.GetComponent<SetHints>().isCustom == true)
                {
                    setCustomHints(g);
                }
                else
                {
                    setHints(g);
                }
            }
        }

        foreach (GameObject g in tohide)
        {
            g.SetActive(false);
        }
    }

    //set hints in game mode
    void setHints(GameObject g)
    {
        if (SetHints.hintCount > 0)
        {
            SetHints.hintCount--;
            GameObject.Find("HintButtonText").GetComponent<Text>().text = "Hints (" + SetHints.hintCount + "/3)";
            g.transform.Find("HintsCount").GetComponent<Text>().text = "Remaining Hints: " + SetHints.hintCount;
            // Check if puzzle solved
            GameObject puzzle1 = g.transform.GetComponent<SetHints>().puzzle1;
            GameObject puzzle2 = g.transform.GetComponent<SetHints>().puzzle2;
            GameObject puzzle3 = g.transform.GetComponent<SetHints>().puzzle3;
            bool puzzle1Solved = puzzle1.transform.GetComponent<PuzzleTracker>().isSolved;
            bool puzzle2Solved = puzzle2.transform.GetComponent<PuzzleTracker>().isSolved;
            bool puzzle3Solved = puzzle3.transform.GetComponent<PuzzleTracker>().isSolved;
            string[] hints = g.transform.GetComponent<SetHints>().hints;
            if (puzzle3Solved == true)
            {
                g.transform.Find("Image").transform.Find("Hints").GetComponent<Text>().text = "Are you sure you want hints but not escape?";
            }
            else
            {
                if (puzzle2Solved == true && SetHints.currentHints < 6)
                {
                    SetHints.currentHints = 6;
                }
                else if (puzzle1Solved == true && SetHints.currentHints < 3)
                {
                    SetHints.currentHints = 3;
                }
                g.transform.Find("Image").transform.Find("Hints").GetComponent<Text>().text = hints[SetHints.currentHints];
                SetHints.currentHints++;
            }

        }
        else
        {
            g.transform.Find("Image").transform.Find("Hints").GetComponent<Text>().text = "You have no more hints!";
        }
    }

    //set hints in custom mode
    void setCustomHints(GameObject g)
    {
        string[] hints = g.transform.GetComponent<SetHints>().hints;
        if (SetHints.hintCount > 0)
        {
            SetHints.hintCount--;
            GameObject.Find("HintButtonText").GetComponent<Text>().text = "Hints (" + SetHints.hintCount + "/3)";
            g.transform.Find("HintsCount").GetComponent<Text>().text = "Remaining Hints: " + SetHints.hintCount;
            g.transform.Find("Image").transform.Find("Hints").GetComponent<Text>().text = hints[SetHints.currentHints];
            SetHints.currentHints++;
        }
        else
        {
            g.transform.Find("Image").transform.Find("Hints").GetComponent<Text>().text = "You have no more hints!";
        }
    }
}
