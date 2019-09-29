using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationPanel : MonoBehaviour
{
    public GameObject msgPan;
    // Start is called before the first frame update
    void Start()
    {
        //msgPan = GameObject.Find("MessageInputPanel");
        msgPan.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            RectTransform rt = child.GetComponent<RectTransform>();
            if (rt.sizeDelta.x != rt.sizeDelta.y)
            {
                rt.sizeDelta = new Vector2(rt.sizeDelta.y, rt.sizeDelta.y);
            }
        }
    }
}
