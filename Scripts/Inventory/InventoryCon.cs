using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCon : MonoBehaviour
{
    private List<GameObject> slots;
    private int size;
    public List<string> items;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<GameObject>();
        items = new List<string>();
        foreach (Transform child in transform)
        {
            slots.Add(child.gameObject);
        }
        size = slots.Count;
        //AddItem("ClueCard1");
        //AddItem("ClueCard2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int AddItem(string name)
    {
        if (items.Count >= size)
        {
            print("item count: " + items.Count);
            return 1;
        }
        else
        {
            items.Add(name);
            foreach (GameObject s in slots)
            {
                //Debug.Log(s.GetComponent<SlotCon>().itemname == null);
                if (s.GetComponent<SlotCon>().itemname == null)
                {
                    
                    s.GetComponent<SlotCon>().Add(name);
                    break;
                }
            }
            print("success add: " + name);
            return 0;
        }
    }

    public int RemoveItem(string name)
    {
        if (items.Contains(name))
        {
            items.Remove(name);
            foreach (GameObject s in slots)
            {
                if (s.GetComponent<SlotCon>().itemname == name)
                {
                    s.GetComponent<SlotCon>().Remove();
                }
            }
        }
        else
        {
            return 1;
        }
        
        return 0;
    }
    public int contains(string name)
    {
        if(items.Contains(name))
        {
            return 1;
        }
        return 0;
    }
}
