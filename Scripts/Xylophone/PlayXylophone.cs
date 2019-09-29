using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayXylophone : MonoBehaviour
{

    public GameObject xylophoneTextObj;
    public GameObject keypadObj;

    int hitCount = 0;
    bool isCorrectSequence = false;
    bool isChosenPuzzle = false;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject obj = hit.collider.gameObject;
                    
                    if (hit.distance <= 1.0 && (obj.tag == "Xylophone"))
                    {

                        AudioSource audioData = obj.GetComponent<AudioSource>();
                        audioData.Play();

                        if (isChosenPuzzle == true)
                        {

                            hitCount++;

                            if (hitCount == 1)
                            {
                                if (obj.name == "RedBar")
                                {
                                    isCorrectSequence = true;
                                }
                            }
                            else if (hitCount == 2)
                            {
                                if (obj.name != "BlueBar" && isCorrectSequence == true)
                                {
                                    isCorrectSequence = false;
                                }
                            }
                            else if (hitCount == 3)
                            {
                                if (obj.name != "YellowBar" && isCorrectSequence == true)
                                {
                                    isCorrectSequence = false;
                                }
                            }
                            else if (hitCount == 4)
                            {
                                if (obj.name != "GreenBar" && isCorrectSequence == true)
                                {
                                    isCorrectSequence = false;
                                }
                                if (isCorrectSequence == true)
                                {
                                    xylophoneTextObj.GetComponent<Text>().text = keypadObj.GetComponent<passcodeCustomize>().answer;
                                    Debug.Log("Correct sequence");
                                    isCorrectSequence = false;
                                }
                                hitCount = 0;
                            }
                        }
                    }
                }
            }
        }
    }

    public void hideXylophoneText()
    {
        int hitCount = 0;
        bool isCorrectSequence = false;
        xylophoneTextObj.GetComponent<Text>().text = "";
    }

    public void setChosen()
    {
        isChosenPuzzle = true;
    }

    public void setNotChosen()
    {
        isChosenPuzzle = false;
    }
}
