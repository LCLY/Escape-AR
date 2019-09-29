using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPositionCamera : MonoBehaviour
{
    public Camera cam;
    bool moving;
    List<Vector3> targetPosList;
    List<Vector3> targetRotList;
    Camera target;
    int speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPosList = new List<Vector3>();
        targetRotList = new List<Vector3>();
        speed = 3;
        moving = false;
        target = new Camera();
        targetPosList.Add(new Vector3(-0.587f, 0.925f, -0.365f));
        targetRotList.Add(new Vector3(30, 90, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            cam.transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
            cam.transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, speed * Time.deltaTime);
            if (cam.transform.position == target.transform.position && cam.transform.eulerAngles == target.transform.eulerAngles)
            {
                moving = false;
            }
        }
    }

    public void KeyPos1()
    {
        target.transform.position = targetPosList[0];
        target.transform.localEulerAngles = targetRotList[0];
        moving = true;
    }
}
