using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCombineFunc : MonoBehaviour
{
    public GameObject itemMenuPanel;
    public GameObject inventoryPanel;

    private ItemMenuCon imc;
    private InventoryCon ic;
    private FadeFX msg;
    // Start is called before the first frame update
    void Start()
    {
        imc = itemMenuPanel.GetComponent<ItemMenuCon>();
        ic = inventoryPanel.GetComponent<InventoryCon>();
        msg = itemMenuPanel.GetComponent<ItemMenuCon>().msg.GetComponent<FadeFX>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (!imc.incombine)
        {
            imc.incombine = true;
            msg.DisplayMsg("click on the other part to combine");
        }
        
    }

    public int CombineItem(string a, string b)
    {
        if (string.Compare(imc.invcom[a], b) == 0)
        {
            Debug.Log("combining" + a + b);
            Debug.Log(imc.combined[a]);
            Debug.Log(a);
            Debug.Log(ic);
            ic.RemoveItem(a);
            ic.RemoveItem(b);
            
            ic.AddItem(imc.combined[a]);
            msg.DisplayMsg("items combined");
            imc.incombine = false;
            itemMenuPanel.SetActive(false);
            return 0;
        }
        else
        {
            msg.DisplayMsg("items don't match");
            imc.incombine = false;
            itemMenuPanel.SetActive(false);
            return 1;
        }
    }
}
