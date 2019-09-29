using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineObject : MonoBehaviour
{
    Camera mainCam;
    GameObject clickedObject;
    //public Canvas inspectionCanvas;

    Vector3 originalPosition;
    Vector3 originalRotation;
    Vector3 lastPosition;

    bool examineMode;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        examineMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        ClickOnObject();

        UpdateObjectPosition();
    }

    void ClickOnObject()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began && touch.tapCount == 2)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject obj = hit.collider.gameObject;

                    GameObject parent = obj.transform.parent.gameObject;

                    if (hit.distance <= 1.0 && (parent.name == "AlphabetBlock" || parent.tag == "Extra"))
                    {
                        if (examineMode == false)
                        {
                            if (parent.name == "Silly_Phone")
                            {
                                clickedObject = obj.transform.parent.gameObject.transform.Find("Phone_handle").gameObject;
                                AudioSource audioData = clickedObject.GetComponent<AudioSource>();
                                audioData.Play();
                            }
                            else if (parent.name == "AlphabetBlock")
                            {
                                clickedObject = obj;
                            }
                            else
                            {
                                clickedObject = parent;
                            }


                            originalPosition = clickedObject.transform.position;
                            originalRotation = clickedObject.transform.rotation.eulerAngles;

                            clickedObject.transform.position = mainCam.transform.position + (mainCam.transform.forward * 0.4f);
                            lastPosition = clickedObject.transform.position;
                            //foreach (GameObject g in toshow)
                            //{
                            //    g.SetActive(true);
                            //}
                            //GameObject.Find("InspectionCanvas").SetActive(true);
                            //inspectionCanvas.gameObject.SetActive(true);

                            examineMode = true;
                        }
                        else
                        {
                            if (clickedObject.name == "Phone_handle")
                            {
                                AudioSource audioData = clickedObject.GetComponent<AudioSource>();
                                audioData.Stop();
                            }
                            clickedObject.transform.position = originalPosition;
                            clickedObject.transform.eulerAngles = originalRotation;
                            //GameObject.Find("InspectionCanvas").SetActive(false);
                            examineMode = false;
                        }
                    }
                }
            }
            //Rotate object on touch hold
            else if (touch.phase == TouchPhase.Moved)
            {
                if (examineMode == true)
                {
                    float rotationSpeed = 15;

                    float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
                    float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

                    clickedObject.transform.Rotate(Vector3.up, -xAxis, Space.World);
                    clickedObject.transform.Rotate(Vector3.right, -yAxis, Space.World);
                }
            }
        }
    }

    //update object position when camera moves
    void UpdateObjectPosition()
    {
        if (examineMode == true)
        {
            Vector3 newPosition = mainCam.transform.position + (mainCam.transform.forward * 0.4f);

            if (Vector3.Distance(lastPosition, newPosition) > 0.05)
            {
                clickedObject.transform.position = newPosition;
                lastPosition = newPosition;
            }
            if (Vector3.Distance(lastPosition, originalPosition) > 1.0)
            {
                clickedObject.transform.position = originalPosition;
                clickedObject.transform.eulerAngles = originalRotation;
                examineMode = false;
            }
        }
    }

}
