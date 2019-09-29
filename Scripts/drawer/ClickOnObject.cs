using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnObject : MonoBehaviour
{
    //public static InventoryHandler inventory = new InventoryHandler();
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        //inventory = GameObject.Find("InventoryPanel");
        //if(inventory == null)
        //{
        //    inventory = new InventoryHandler();
        //}
        /*
        GameObject[] objects = GameObject.FindGameObjectsWithTag("InventoryItemImage");
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        print("Finish disabling objs");
        */
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //for mouse

        /*if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                //Debug.Log("obj: " + obj.name);
                if (obj.tag == "Collectable" || obj.tag == "keys")
                {

                    obj.SetActive(false);
                    if (inventory.GetComponent<InventoryCon>().contains(obj.name) == 0)
                    {
                        inventory.GetComponent<InventoryCon>().AddItem(obj.name);
                    }
                    else
                    {
                        inventory.GetComponent<InventoryCon>().RemoveItem(obj.name);
                        inventory.GetComponent<InventoryCon>().AddItem(obj.name);
                    }

                    //inventory.GetComponent<InventoryCon>().AddItem(obj.name);
                    //inventory.addItem(obj);

                }
            }
        }*/

            if (Input.touchCount > 0)
            {
                var touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began && touch.tapCount == 2)
                {


                    if (Physics.Raycast(ray, out hit))
                    {
                        //Debug.Log(" you clicked on " + hit.collider.gameObject.tag);

                        GameObject obj = hit.collider.gameObject;

                        if (obj.tag == "Collectable" || obj.tag == "keys")
                        {

                            obj.SetActive(false);
                            if (inventory.GetComponent<InventoryCon>().contains(obj.name) == 0)
                            {
                                inventory.GetComponent<InventoryCon>().AddItem(obj.name);
                            }
                            else
                            {
                                inventory.GetComponent<InventoryCon>().RemoveItem(obj.name);
                                inventory.GetComponent<InventoryCon>().AddItem(obj.name);
                            }

                            //inventory.GetComponent<InventoryCon>().AddItem(obj.name);
                            //inventory.addItem(obj);

                        }
                    }

                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        GameObject obj = hit.collider.gameObject;

                        if (obj.tag == "Collectable" || obj.tag == "keys")
                        {
                            float rotationSpeed = 10;

                            float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
                            float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

                            obj.transform.Rotate(Vector3.up, -xAxis, Space.World);
                            obj.transform.Rotate(Vector3.right, -yAxis, Space.World);
                        }
                    }
                }
            }
        }
    }


    //private void OnMouseDown()
    //{



    //    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    //    RaycastHit hit;

    //    //    if (Input.touchCount > 0)
    //    //    {
    //    //        var touch = Input.touches[0];
    //    //        if (touch.phase == TouchPhase.Began)
    //    //        {
    //    //            Debug.Log("touch phase began");

    //    //            if (Physics.Raycast(ray, out hit))
    //    //            {
    //    //                Debug.Log(" you clicked on " + hit.collider.gameObject.tag);

    //    //                GameObject obj = hit.collider.gameObject;

    //    //                if(obj.tag == "Collectable" || obj.tag == "keys")
    //    //                {

    //    //                    obj.SetActive(false);

    //    //                    if(inventory.GetComponent<InventoryCon>().contains(obj.name) == 0)
    //    //                    {
    //    //                        inventory.GetComponent<InventoryCon>().AddItem(obj.name);
    //    //                    }
    //    //                    else
    //    //                    {
    //    //                        inventory.GetComponent<InventoryCon>().RemoveItem(obj.name);
    //    //                        inventory.GetComponent<InventoryCon>().AddItem(obj.name);
    //    //                    }

    //    //                    //inventory.addItem(obj);

    //    //                }
    //    //            }

    //    //        }
    //    //    }
    //}

