using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPhone : MonoBehaviour
{
    Camera mainCam;

    GameObject clickedObject;

    Vector3 originalPosition;
    Vector3 lastPosition;

    bool isPickUp;
    bool isCorrectSequence;
    bool isChosenPuzzle;
    int hitCount;
    int currentPasscode;

    public AudioSource phoneAudio;
    public AudioClip[] phoneButtonAudio;
    public GameObject keypadObj;
    public GameObject phoneTextObj;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        isPickUp = false;
        isCorrectSequence = false;
        isChosenPuzzle = false;
        hitCount = 0;
        currentPasscode = 0;
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

                    if (hit.distance <= 1.0 && (obj.tag == "PhoneButton"))
                    {
                        if (isChosenPuzzle == true)
                        {
                            AudioSource audioData = obj.GetComponent<AudioSource>();
                            audioData.Play();

                            hitCount++;
                            if (hitCount == 1)
                            {
                                if (obj.name == "PhoneButton1")
                                {
                                    isCorrectSequence = true;
                                }
                            }
                            else if (hitCount == 2)
                            {
                                if (obj.name != "PhoneButton4" && isCorrectSequence == true)
                                {
                                    isCorrectSequence = false;
                                }
                            }
                            else if (hitCount == 3)
                            {
                                if (obj.name != "PhoneButton2" && isCorrectSequence == true)
                                {
                                    isCorrectSequence = false;
                                }
                            }
                            else if (hitCount == 4)
                            {
                                if (obj.name != "PhoneButton3" && isCorrectSequence == true)
                                {
                                    isCorrectSequence = false;
                                }
                                hitCount = 0;
                            }
                        }
                    }

                    if (isPickUp == false)
                    {
                        if (hit.distance <= 1.0 && (obj.name == "Phone_handle"))
                        {
                            clickedObject = obj;

                            if (hitCount == 0 && isCorrectSequence == true)
                            {
                                Debug.Log("Correct sequence"); 
                                phoneTextObj.GetComponent<Text>().text = keypadObj.GetComponent<passcodeCustomize>().answer;
                                isCorrectSequence = false;
                                phoneAudio.Play();
                            }
                            else
                            {
                                AudioSource audioData = clickedObject.GetComponent<AudioSource>();
                                audioData.Play();
                            }

                            originalPosition = clickedObject.transform.position;

                            clickedObject.transform.position = mainCam.transform.position + (mainCam.transform.forward * 0.4f);
                            lastPosition = clickedObject.transform.position;

                            isPickUp = true;
                        }
                    }
                    else
                    {
                        if (clickedObject.name == "Phone_handle")
                        {
                            AudioSource audioData = clickedObject.GetComponent<AudioSource>();
                            audioData.Stop();
                            phoneAudio.Stop();

                            clickedObject.transform.position = originalPosition;

                            isPickUp = false;
                        }
                    }
                }
            }
        }

    }

    public void resetPhoneText()
    {
        isPickUp = false;
        isCorrectSequence = false;
        hitCount = 0;
        currentPasscode = 0;
        phoneTextObj.GetComponent<Text>().text = "Rainbow";
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
