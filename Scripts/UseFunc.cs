using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseFunc : MonoBehaviour
{
    private Dictionary<string, string> usemap;
    private FadeFX msg;
    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("ItemMenuPanel").GetComponent<ItemMenuCon>().msg.GetComponent<FadeFX>();
        usemap = new Dictionary<string, string>();
        usemap.Add("Worn_Key", "Chest");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        string item = GameObject.Find("ItemMenuPanel").GetComponent<ItemMenuCon>().itemname;
        
        if (item != null)
        {
            Debug.Log("choose an object to use");
            msg.DisplayMsg("choose an object to use");
            //GameObject target;

            //GameObject.Find("ClickManager").GetComponent<ClickManager>().obj = null;
            StartCoroutine(WaitToUse(item));
            
            /*GameObject target = GameObject.Find("ClickManager").GetComponent<ClickManager>().obj;

            if (string.Compare(target.name,usemap[item]) == 0)
            {
                GameObject.Find("InventoryPanel").GetComponent<InventoryCon>().RemoveItem(item);
                Debug.Log("item used");
            }
            else
            {
                Debug.Log(item + " cannot be used on " + target.name);
            }*/
        }
        else
        {
            Debug.Log("no item using");
            msg.DisplayMsg("no item using");
            GameObject.Find("ItemMenuPanel").SetActive(false);
        }
        
    }

    IEnumerator WaitToUse(string item)
    {
        
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    GameObject target = hit.transform.gameObject;
                    if (usemap.ContainsKey(item) && string.Compare(target.name, usemap[item]) == 0)
                    {
                        GameObject.Find("InventoryPanel").GetComponent<InventoryCon>().RemoveItem(item);
                        target.GetComponent<ObjectUseFunc>().UseIt();
                        Debug.Log("item used");
                        msg.DisplayMsg("item used");

                    }
                    else
                    {
                        Debug.Log(item + " cannot be used on " + target.name);
                        msg.DisplayMsg(item + " cannot be used on " + target.name);
                    }
                    break;
                }
            }
            yield return null;
        }
        GameObject.Find("ItemMenuPanel").SetActive(false);
    }

    
}
