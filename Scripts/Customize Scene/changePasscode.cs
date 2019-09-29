using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePasscode : MonoBehaviour
{
    public GameObject keypadObj;
    public GameObject newPasscodeTextObj;
    Text passcodeText;
    passcodeCustomize passcodeScript;

    // Start is called before the first frame update
    void Start()
    {
        passcodeScript = keypadObj.GetComponent<passcodeCustomize>();
        passcodeText = newPasscodeTextObj.GetComponent<Text>();
    }

    public void changeThePassCode()
    {
        passcodeScript.answer = passcodeText.text;
        transform.parent.gameObject.SetActive(false);
    }
        
}
