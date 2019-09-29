using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenuCon : MonoBehaviour
{
    public string itemname;
    public GameObject msg;
    public bool incombine;
    public Dictionary<string, string> invcom;
    public Dictionary<string, string> combined;
    // Start is called before the first frame update
    void Start()
    {
        incombine = false;
        invcom = new Dictionary<string, string>();
        invcom.Add("ClueCard1", "ClueCard2");
        invcom.Add("ClueCard2", "ClueCard1");
        combined = new Dictionary<string, string>();
        combined.Add("ClueCard1", "ClueCard");
        combined.Add("ClueCard2", "ClueCard");
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
