using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCon : MonoBehaviour
{
    List<GameObject> options;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        options = new List<GameObject>();
        foreach (Transform child in transform)
        {
            options.Add(child.gameObject);
        }
        gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(1, options.Count + 1);
        gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject a in options)
        {
            RectTransform tmp = a.GetComponent<RectTransform>();
            tmp.sizeDelta = new Vector2(tmp.sizeDelta.x, tmp.sizeDelta.x);
        }
            
    }
}
