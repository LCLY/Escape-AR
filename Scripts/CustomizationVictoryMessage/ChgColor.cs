using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChgColor : MonoBehaviour
{
    public GameObject parentPanel;
    public GameObject panel;
    public Sprite background1;
    public Sprite background2;
    public Sprite background3;  
    Image panelImage;
    void Start()
    {
        panelImage = panel.GetComponent<Image>();
    }

    public void Red()
    {
        if (!parentPanel.activeInHierarchy)
        {
            parentPanel.SetActive(true);
        }     
        //panel.color = UnityEngine.Color.red;
        panelImage.sprite = background1;
        Debug.Log("Changed color to Red");    }

    public void Blue()
    {
        if (!parentPanel.activeInHierarchy)
        {
            parentPanel.SetActive(true);
        }
        //panel.color = UnityEngine.Color.blue;
        panelImage.sprite = background2;
        Debug.Log("Changed color to Blue");
    }

    public void Green()
    {
        if (!parentPanel.activeInHierarchy)
        {
            parentPanel.SetActive(true);
        }
        panelImage.sprite = background3;
        //panel.color = UnityEngine.Color.green;
        Debug.Log("Changed color to Green");
    }
}
