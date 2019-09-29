using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationPanelMaskScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenList()
    {
        Debug.Log("cpm op");
        RectTransform rt1 = transform.GetComponent<RectTransform>();
        rt1.anchorMax = new Vector2(rt1.anchorMax.x, 6.2f);
        rt1.offsetMax = new Vector2(rt1.offsetMax.x, 0);
        Debug.Log(rt1.anchorMax);
        Debug.Log(rt1.offsetMax);
    }

    public void CloseList()
    {
        RectTransform rt1 = transform.GetComponent<RectTransform>();
        rt1.anchorMax = new Vector2(rt1.anchorMax.x, 0.8f);
        rt1.offsetMax = new Vector2(rt1.offsetMax.x, 0);
    }
}
