using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayXyloInGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject obj = hit.collider.gameObject;

                    if (hit.distance <= 1.0 && (obj.tag == "Xylophone"))
                    {

                        AudioSource audioData = obj.GetComponent<AudioSource>();
                        audioData.Play();

                    }
                }
            }
        }
    }
}
