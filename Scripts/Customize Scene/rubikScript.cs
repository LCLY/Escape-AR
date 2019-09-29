using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubikScript : MonoBehaviour
{
    public GameObject solved;
    public GameObject mixed;
    // Start is called before the first frame update
    void Start()
    {
        solved.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                //Debug.Log("obj: " + obj.name);
                if (obj.name == "RubikCube_Mixed")
                {
                    mixed.SetActive(false);
                    solved.SetActive(true);
                }
            }
        }
    }


}
