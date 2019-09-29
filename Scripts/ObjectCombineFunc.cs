using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCombineFunc : MonoBehaviour
{
    // Start is called before the first frame update
    public string methodname;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CombineIt()
    {
        GameObject.Find("Chest of drawers").GetComponent<RevealHandle>().Invoke(methodname, 0);
        return 0;
    }
}
