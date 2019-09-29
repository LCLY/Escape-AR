using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineFunc : MonoBehaviour
{
    private Dictionary<string, string> combinemap;
    private FadeFX msg;

    public GameObject chestOfDrawers;

    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("ItemMenuPanel").GetComponent<ItemMenuCon>().msg.GetComponent<FadeFX>();
        combinemap = new Dictionary<string, string>();
        combinemap.Add("Drawer_Med1_Handle", "Drawer_Med1");
        combinemap.Add("Drawer_Med2_Handle", "Drawer_Med2");
        combinemap.Add("Drawer_Big2_Handle", "Drawer_Big2");      
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
            Debug.Log("choose an object to fix");
            msg.DisplayMsg("choose an object to fix");
            //GameObject target;

            //GameObject.Find("ClickManager").GetComponent<ClickManager>().obj = null;
            StartCoroutine(WaitToCombine(item));

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

    IEnumerator WaitToCombine(string item)
    {

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    GameObject target = hit.transform.gameObject;
                    if (combinemap.ContainsKey(item) && string.Compare(target.name, combinemap[item]) == 0)
                    {
                        Debug.Log(target.name + " fixed");
                        msg.DisplayMsg(target.name + " fixed");
                        // target.GetComponent<ObjectCombineFunc>().CombineIt();
                        GameObject.Find("InventoryPanel").GetComponent<InventoryCon>().RemoveItem(item); 
                        switch (target.name)
                        {
                            case "Drawer_Med1":
                                Debug.Log("calling reveal");
                                chestOfDrawers.GetComponent<RevealHandle>().reveal_Med1_Handle();
                                Debug.Log("reveal called");
                                break;
                            case "Drawer_Med2":
                                chestOfDrawers.GetComponent<RevealHandle>().reveal_Med2_Handle();
                                break;
                            case "Drawer_Big2":
                                chestOfDrawers.GetComponent<RevealHandle>().reveal_Big2_Handle();
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        Debug.Log(target.name + " cannot be fixed with " + item);
                        msg.DisplayMsg(target.name + " cannot be fixed with " + item);
                    }
                    break;
                }
            }
            yield return null;
        }
        GameObject.Find("ItemMenuPanel").SetActive(false);
    }
}
