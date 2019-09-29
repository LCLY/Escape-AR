using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Vuforia;
namespace cakeslice
{
    public class ObjectDetection : MonoBehaviour
    {
        private GameObject dungeon;
        private Light ceilingLight1;
        private Light ceilingLight2;
        private Light ceilingLight3;
        private Light directionalLight;
        public GameObject spotlightObj;
        private Light spotLight;
        //private Camera mainCamera;
        private Plane ground;      
        private bool tap = false;
        private Vector3 originalPos;    // Start is called before the first frame update
        private GameObject cube;
        void Start()
        {
            //this is the outline part
            /*if (GetComponent<Outline>().enabled == true)
            {
                GetComponent<Outline>().enabled = false;
            }*/
            ceilingLight1 = GameObject.Find("CeilingLight1").GetComponent<Light>();
            ceilingLight2 = GameObject.Find("CeilingLight2").GetComponent<Light>();
            ceilingLight3 = GameObject.Find("CeilingLight3").GetComponent<Light>();
            directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
            spotLight = spotlightObj.GetComponent<Light>();
            //mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            ground = GameObject.FindWithTag("Ground").GetComponent<Plane>();

            dungeon = GameObject.Find("Dungeon");
            if (dungeon != null)
            {
                dungeon.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            if (ceilingLight1 == null || ceilingLight2 == null)
            {
                Debug.Log("Can't find the CeilingLight");
            }
            if (spotLight == null)
            {
                Debug.Log("Can't find the SpotLight");
            }
            /*if (mainCamera == null)
            {
                Debug.Log("Can't find the main Camera");
            }*/
            //if(ground.Equals(null))
            //{
            //    Debug.Log("Can't find the ground");

            //}

            ceilingLight1.enabled = true;
            ceilingLight2.enabled = true;
            ceilingLight3.enabled = true;
            directionalLight.enabled = true;
            spotLight.enabled = false;       

        }

        // Update is called once per frame
        void Update()
        {           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.touchCount > 0)
            {
                var touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("touch phase began");

                    if (!Physics.Raycast(ray, out hit))
                    {

                        Debug.Log("Not clicking on objects");
                        if (cube != null && originalPos != null)
                        {
                            cube.transform.position = originalPos;
                            //GetComponent<Outline>().enabled = !GetComponent<Outline>().enabled;
                        }

                    }

                }

            }


        }
        private void OnMouseDown()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.touchCount > 0)
            {
                var touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("touch phase began");

                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(" you clicked on " + hit.collider.gameObject.tag);

                        if (hit.collider.gameObject.tag == "Highlight")
                        {
                            //original code
                            //if an object has been tapped, the lights should stay off
                            ceilingLight1.enabled = !ceilingLight1.enabled;
                            ceilingLight2.enabled = !ceilingLight2.enabled;
                            ceilingLight3.enabled = !ceilingLight3.enabled;
                            directionalLight.enabled = !directionalLight.enabled;
                            //GetComponent<Outline>().enabled = true;
                            spotLight.enabled = !spotLight.enabled;
                            /*if (tap == true)
                            {
                                ceilingLight1.enabled = false;
                                ceilingLight2.enabled = false;
                                ceilingLight3.enabled = false;
                                directionalLight.enabled = false;
                                //GetComponent<Outline>().enabled = true;
                                spotLight.enabled = true;
                            }
                            else
                            {
                                ceilingLight1.enabled = true;
                                ceilingLight2.enabled = true;
                                ceilingLight3.enabled = true;
                                directionalLight.enabled = true;
                                //GetComponent<Outline>().enabled = true;
                                spotLight.enabled = false;
                            }*/
                            //myLight.enabled = !myLight.enabled;
                            cube = hit.collider.gameObject;
                            //if(originalPos == null)
                            //{ 
                            //   originalPos = cube.transform.position;
                            //}


                            //cube.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 0.2f;

                            Vector3 temp;

                            if (!tap)
                            {
                                originalPos = cube.transform.position;
                                //cube.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 1f;
                                temp = cube.transform.position;
                                temp.y -= 0.2f;
                                cube.transform.position = temp;//supposed to lower down the object abit
                                tap = true;
                            }
                            else
                            {
                                //if(originalPos != null)
                                //{
                                //    cube.transform.position = originalPos;
                                //}
                                //else
                                //{


                                cube.transform.position = originalPos;
                                //}

                                tap = false;

                            }


                            //lights= FindObjectOfType(typeof(Light)) as Light[];

                            // Write things you want to do when you click.
                        }
                        else if (hit.collider.gameObject.name == "Sphere")
                        {
                            GameObject sphere = hit.collider.gameObject;

                            Debug.Log(sphere.transform.position);
                        }
                        //else
                        //{
                        //    Debug.Log("Not clicking on objects");
                        //    if (cube != null && originalPos != null)
                        //    {
                        //        cube.transform.position = originalPos;
                        //    }
                        //}
                    }

                }
                //else
                //{
                //    Debug.Log("touch phase not triggered");
                //}
            }
            //else
            //{
            //    Debug.Log("touch count not greater than 0");
            //}
        }
    }

}