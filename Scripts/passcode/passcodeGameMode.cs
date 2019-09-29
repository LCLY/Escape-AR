using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class passcodeGameMode : MonoBehaviour
{
    //EndGamePanel
    public GameObject MsgPanel;
    //PASSCODE IS IN KEYPAD  
    public GameObject keypad;
    Animator keys;
    //to get the script  

    Text outputString;
    public GameObject output;    

    public GameObject greenLight;
    Material oriGreen;
    public Material greenEmission;

    public GameObject redLight;
    Material oriRed;
    public Material redEmission;

    public GameObject door;
    Animator doorOpen;    

    public string answer = "1234";
    static string input = "";
    static int totalDigits = 0;
    public static Timer timer;

    public GameObject clickSoundObj;
    AudioSource clickSound;
    public GameObject doorSoundObj;
    AudioSource doorSound;
    public GameObject unlockSoundObj;
    AudioSource unlockSound;
    public GameObject wrongSoundObj;
    AudioSource wrongSound;



    // Start is called before the first frame update
    void Start()
    {
        oriGreen = greenLight.GetComponent<MeshRenderer>().material;
        oriRed = redLight.GetComponent<MeshRenderer>().material;
        outputString = output.GetComponent<Text>();      
        doorOpen = door.GetComponent<Animator>();
        keys = keypad.GetComponent<Animator>();
        doorSound = doorSoundObj.GetComponent<AudioSource>();
        clickSound = clickSoundObj.GetComponent<AudioSource>();
        unlockSound = unlockSoundObj.GetComponent<AudioSource>();
        wrongSound = wrongSoundObj.GetComponent<AudioSource>();     
        timer = new Timer();
        DontDestroyOnLoad(this.gameObject);
    }

  
    // Update is called once per frame
    void Update()
    {     
        /* ============================== TOUCH ==============================*/
        //Debug.Log("the Total digits is: " + totalDigits);
        //Debug.Log("The password is: " + input);   
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log(" In passcode: you clicked on " + hit.collider.gameObject.name);

                    GameObject obj = hit.collider.gameObject;
                    if (totalDigits >= 4)
                    {
                        //Debug.Log("Clear the numbers!");
                        switch (obj.name)
                        {
                            case "key10"://CLEAR KEY
                                //Debug.Log("Clicked key10");
                                clickSound.Play();
                                outputString.text = "";
                                input = "";//reset input string
                                totalDigits = 0;
                                keys.SetTrigger("key10");
                                greenLight.GetComponent<MeshRenderer>().material = oriGreen;
                                redLight.GetComponent<MeshRenderer>().material = oriRed;
                                break;
                            case "key12"://ENTER KEY
                                //Debug.Log("Clicked key12");
                                clickSound.Play();
                                keys.SetTrigger("key12");
                                if (totalDigits >= 4)
                                {
                                    if (input == answer)
                                    {
                                        //change the light
                                        greenLight.GetComponent<MeshRenderer>().material = greenEmission;
                                        //trigger door animation
                                        doorOpen.SetTrigger("open");
                                        doorSound.Play();
                                        //correct sound effect    
                                        unlockSound.Play();
                                        
                                        print("saving elapsed time");
                                        timer.Save();
                                        timer.Print();
                                        print("saved elapsed time");
                                        
                                        //set puzzle as solved
                                        keypad.transform.GetComponent<PuzzleTracker>().isSolved = true;
                                        UpdatePuzzleNumber.remainingPuzzleNum -= 1;
                                        UpdatePuzzleNumber.UpdateRemainingPuzzleNumText();
                                        //Debug.Log("Correct!");
                                        Invoke("ActivateMsgPanel", 5f);
                                    }
                                    else
                                    {
                                        //wrong sound effect
                                        wrongSound.Play();
                                        //change to red light   
                                        redLight.GetComponent<MeshRenderer>().material = redEmission;
                                        //Debug.Log("Incorrect!");
                                    }

                                }
                                else if (totalDigits < 4)
                                {
                                    redLight.GetComponent<MeshRenderer>().material = redEmission;
                                }
                                break;
                            default:
                                //Debug.Log("neither");
                                break;
                        }

                    }
                    else
                    {
                        switch (obj.name)
                        {
                            case "key1":
                                //Debug.Log("Clicked key1");
                                clickSound.Play();
                                input += "1";
                                outputString.text += "1";
                                totalDigits++;
                                keys.SetTrigger("key1");
                                break;
                            case "key2":
                                //Debug.Log("Clicked key2");
                                clickSound.Play();
                                input += "2";
                                outputString.text += "2";
                                totalDigits++;
                                keys.SetTrigger("key2");
                                break;
                            case "key3":
                                //Debug.Log("Clicked key3");
                                clickSound.Play();
                                input += "3";
                                outputString.text += "3";
                                totalDigits++;
                                keys.SetTrigger("key3");
                                break;
                            case "key4":
                                //Debug.Log("Clicked key4");
                                clickSound.Play();
                                input += "4";
                                outputString.text += "4";
                                keys.SetTrigger("key4");
                                totalDigits++;
                                break;
                            case "key5":
                                //Debug.Log("Clicked key5");
                                clickSound.Play();
                                input += "5";
                                outputString.text += "5";
                                keys.SetTrigger("key5");
                                totalDigits++;
                                break;
                            case "key6":
                                //Debug.Log("Clicked key6");
                                clickSound.Play();
                                input += "6";
                                outputString.text += "6";
                                keys.SetTrigger("key6");
                                totalDigits++;
                                break;
                            case "key7":
                                //Debug.Log("Clicked key7");
                                clickSound.Play();
                                input += "7";
                                outputString.text += "7";
                                keys.SetTrigger("key7");
                                totalDigits++;
                                break;
                            case "key8":
                                //Debug.Log("Clicked key8");
                                clickSound.Play();
                                input += "8";
                                outputString.text += "8";
                                keys.SetTrigger("key8");
                                totalDigits++;
                                break;
                            case "key9":
                                //Debug.Log("Clicked key9");
                                clickSound.Play();
                                input += "9";
                                outputString.text += "9";
                                keys.SetTrigger("key9");
                                totalDigits++;
                                break;
                            case "key10"://CLEAR KEY
                                //Debug.Log("Clicked key10");
                                clickSound.Play();
                                outputString.text = "";
                                totalDigits = 0;
                                input = ""; //reset input string
                                keys.SetTrigger("key10");
                                greenLight.GetComponent<MeshRenderer>().material = oriGreen;
                                redLight.GetComponent<MeshRenderer>().material = oriRed;
                                break;
                            case "key11":
                                //Debug.Log("Clicked key11");
                                clickSound.Play();
                                input += "0";
                                outputString.text += "0";
                                keys.SetTrigger("key11");
                                totalDigits++;
                                break;
                            case "key12"://ENTER KEY
                                Debug.Log("Clicked key12");
                                clickSound.Play();
                                keys.SetTrigger("key12");
                                if (totalDigits >= 4)
                                {
                                    if (input == answer)
                                    {
                                        //change the light
                                        greenLight.GetComponent<MeshRenderer>().material = greenEmission;
                                        //trigger door animation
                                        doorOpen.SetTrigger("open");
                                        doorSound.Play();
                                        //correct sound effect  
                                        unlockSound.Play();
                                        
                                        print("saving elapsed time");
                                        timer.Save();
                                        timer.Print();
                                        print("saved elapsed time");
                                        
                                        //set puzzle as solved
                                        keypad.transform.GetComponent<PuzzleTracker>().isSolved = true;
                                        UpdatePuzzleNumber.remainingPuzzleNum -= 1;
                                        UpdatePuzzleNumber.UpdateRemainingPuzzleNumText();
                                        //Debug.Log("Correct!");
                                        Invoke("ActivateMsgPanel", 5f);


                                    }
                                    else
                                    {
                                        //wrong sound effect
                                        wrongSound.Play();
                                        //change to red light   
                                        redLight.GetComponent<MeshRenderer>().material = redEmission;
                                        //Debug.Log("Incorrect!");
                                    }

                                }
                                else if (totalDigits < 4)
                                {
                                    redLight.GetComponent<MeshRenderer>().material = redEmission;
                                }

                                break;
                            default:
                                //Debug.Log("neither");
                                break;
                        }
                    }

            }
        }
        
        /* ============================== TOUCH ==============================*/
    }

    void ActivateMsgPanel ()
    {
        MsgPanel.SetActive(true);
    }
}
