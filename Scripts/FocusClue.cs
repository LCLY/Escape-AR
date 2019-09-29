using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusClue : MonoBehaviour
{
    private RaycastHit cardHit; 
    private bool isTap = false;
    public Texture img;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject obj = hit.collider.gameObject;

            //Debug.Log(" you clicked on " + hit.collider.gameObject.tag);

            if (isTap == true)
            {
                if (Vector3.Distance(hit.point, cardHit.point) >= 3.0)
                {
                    isTap = false;
                }
            }

        }
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began && touch.tapCount == 2)
            {
                Debug.Log("touch phase began");
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject obj = hit.collider.gameObject;

                    Debug.Log(" you clicked on " + hit.collider.gameObject.tag);

                    if (hit.distance <= 1.0 && hit.collider.gameObject.tag == "Cards")
                    {
                        Debug.Log(" you clicked on card");

                        if (isTap == false)
                        {
                            Debug.Log("Rotate card");
                            cardHit = hit;
                            //obj.transform.rotation = Quaternion.Euler(90, 0, 0);
                            isTap = true;
                        }
                        else
                        {
                            Debug.Log("Rotate card back");
                            //obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                            isTap = false;
                        }

                    }
                }
            }
        }

    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isMouse && e.clickCount > 1)
        {
            isTap = false;
        }
        if (isTap == true)
        {
            float width = 512;
            float height = 683;
            GUI.DrawTexture(new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2) - (height / 2), width, height), img);

        }

    }

}
