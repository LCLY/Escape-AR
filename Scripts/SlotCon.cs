using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCon : MonoBehaviour
{
    public GameObject ItemMenuPanel;
    public GameObject InventoryPanel;
    public GameObject InventoryCombineButton;
    public string itemname;
    private string itempicpath;
    public static string itemStr = "";
    public static bool focusing = false;
    private ItemMenuCon imc;
    // Start is called before the first frame update
    void Start()
    {
        itemname = null;
        this.itempicpath = "ItemPics/empty";
        GetComponent<Image>().sprite = Resources.Load<Sprite>(itempicpath);
        imc = ItemMenuPanel.GetComponent<ItemMenuCon>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (focusing)
            {
                touch.phase = TouchPhase.Moved;
            }
        }

         
    }

    public int Add(string itemname)
    {
        this.itemname = itemname;
        this.itempicpath = "ItemPics/" + itemname;
        GetComponent<Image>().sprite = Resources.Load<Sprite>(itempicpath);
        return 0;
    }

    public int Remove()
    {
        itemname = null;
        this.itempicpath = "ItemPics/empty";
        GetComponent<Image>().sprite = Resources.Load<Sprite>(itempicpath);
        return 0;
    }

    public void OnMouseDown()
    {
        if (itemname != null)
        {
            if (!imc.incombine)
            {
                GameObject menu = InventoryPanel.GetComponent<InventoryCon>().menu;
                menu.SetActive(true);
                menu.GetComponent<ItemMenuCon>().itemname = itemname;
                print("item name: " + itemname);
                itemStr = itemname;
                print("itemStr: " + itemStr);
            }
            else
            {
                InventoryCombineButton.GetComponent<InventoryCombineFunc>().CombineItem(imc.itemname, this.itemname);
            }
            
        }
        else
        {
            imc.incombine = false;
            ItemMenuPanel.SetActive(false);
        }
        
    }
    public void focusObject()
    {
        //GameObject obj = GameObject.Find(name);
        GameObject obj = new GameObject();
        print("*******itemStr: " + itemStr);
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject child in objects)
        {
            if ((child.tag == "Collectable" || child.tag == "keys") && child.name == itemStr)
            {
                print("Found obj " + name + "in focusObject");
                obj = child;
                obj.SetActive(true);
                focusing = true;
                break;
            }
        }

        Camera mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        Vector3 originalPos = obj.transform.position;
        obj.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 0.5f;
        Vector3 temp = obj.transform.position;
        temp.y -= 0.2f;

        //cube.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 1f;
        //temp = cube.transform.position;
        //temp.y -= 0.2f;
        //cube.transform.position = temp;//supposed to lower down the object abit
        //tap = true;
    }

}
