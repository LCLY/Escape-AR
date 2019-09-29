using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestItemScript : MonoBehaviour
{
    public GameObject def, it1, it2;
    Vector3 defPos, pos1, pos2, rot1_in;
    Quaternion rot1_def;

    // Start is called before the first frame update
    void Start()
    {
        defPos = def.transform.position;
        pos1 = it1.transform.position;
        pos2 = it2.transform.position;
        rot1_def = it1.transform.rotation;
        rot1_in = new Vector3(0, 45, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Default()
    {
        def.transform.position = defPos;
        it1.transform.position = pos1;
        it1.transform.rotation = rot1_def;
        it2.transform.position = pos2;
    }

    public void Item1()
    {
        def.transform.position = pos1;
        it1.transform.position = defPos;
        it1.transform.rotation = Quaternion.Euler(rot1_in);
        it2.transform.position = pos2;
    }

    public void Item2()
    {
        def.transform.position = pos2;
        def.transform.Translate(new Vector3(-0.03f, 0, 0));
        it1.transform.position = pos1;
        it1.transform.rotation = rot1_def;
        it2.transform.position = defPos;
        it2.transform.Translate(new Vector3(0, -0.06f, 0));
    }
}
