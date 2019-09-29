using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryHandler : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private List<GameObject> inventory = new List<GameObject>();
    GraphicRaycaster raycaster;


    public void OnBeginDrag(PointerEventData eventData)
    {

        Debug.Log("Drag Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Ended");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Mouse Up");
    }

    //void Update()
    //{
    //    print("In Update of inventoryhandler");
    //    //Check if the left Mouse button is clicked
    //    if (Input.touchCount > 0)
    //    {
    //        var touch = Input.touches[0];
    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            //Set up the new Pointer Event
    //            PointerEventData pointerData = new PointerEventData(EventSystem.current);
    //            List<RaycastResult> results = new List<RaycastResult>();

    //            //Raycast using the Graphics Raycaster and mouse click position
    //            pointerData.position = Input.mousePosition;
    //            this.raycaster.Raycast(pointerData, results);

    //            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
    //            foreach (RaycastResult result in results)
    //            {
    //                Debug.Log("Hit " + result.gameObject.name);
    //            }
    //        }
    //    }

    //}

    public void addItem(GameObject item)
    {
        inventory.Add(item);
        print(inventory.Count);
        string itemStr = item.name;
        print(itemStr);
        updateInventoryPanel(itemStr);
       
    }
    void updateInventoryPanel(string itemStr)
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.tag == "InventoryItemImage" && obj.name == itemStr)
            {
                obj.SetActive(true);
            }
        }
    }
    public void focusObject()
    {
        //GameObject obj = GameObject.Find(name);
        GameObject obj = new GameObject();

        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject child in objects)
        {
            if ((child.tag == "Collectable" || child.tag == "keys") && child.name == name)
            {
                print("Found obj " + name + "in focusObject");
                obj = child;
                obj.SetActive(true);
                break;
            }
        }

        Camera mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        Vector3 originalPos = obj.transform.position;
        obj.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 1f;
        Vector3 temp = obj.transform.position;
        temp.y -= 0.2f;

        //cube.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 1f;
        //temp = cube.transform.position;
        //temp.y -= 0.2f;
        //cube.transform.position = temp;//supposed to lower down the object abit
        //tap = true;
    }
   
}
