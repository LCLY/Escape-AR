using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public GameObject msg;

    void Start()
    {
        
    }
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                obj = hit.transform.gameObject;
                Debug.Log(hit.transform.gameObject.name);
                //GameObject.Find("ItemMenuPanel").SetActive(false);
            }
        }*/

        //Debug.Log(msg.GetComponent<CanvasRenderer>().GetAlpha());
        if (msg.GetComponent<CanvasRenderer>().GetAlpha() <= 0.01)
        {
            msg.SetActive(false);
        }
    }
}
