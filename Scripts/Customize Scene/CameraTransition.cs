using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    public Transform currentView;
    public GameObject disableARCameraObj;
    disableARCamera disableScript;

    // Start is called before the first frame update
    void Start()
    {
        disableScript = disableARCameraObj.GetComponent<disableARCamera>();

    }     

    // Update is called once per frame
    void LateUpdate()
    {
        //Lerp the positions
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed), 
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;       
      
    }
}
