using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealHandle : MonoBehaviour
{
    public GameObject drawer_Med1_Handle;
    public GameObject drawer_Med2_Handle;
    public GameObject drawer_Big2_Handle;
    public bool handle1Combined = false;
    public bool handle2Combined = false;
    public bool handle3Combined = false;
    // Start is called before the first frame update
    void Start()
    {
        drawer_Med1_Handle.SetActive(false);
        drawer_Med2_Handle.SetActive(false);
        drawer_Big2_Handle.SetActive(false);
    }

    public void reveal_Med1_Handle()
    {
        drawer_Med1_Handle.SetActive(true);
        handle1Combined = true;
    }

    public void reveal_Med2_Handle()
    {
        drawer_Med2_Handle.SetActive(true);
        handle2Combined = true;
    }

    public void reveal_Big2_Handle()
    {
        drawer_Big2_Handle.SetActive(true);
        handle3Combined = true;
    }
}
