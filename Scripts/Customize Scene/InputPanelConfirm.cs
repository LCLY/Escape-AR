using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPanelConfirm : MonoBehaviour
{
    public GameObject hp;
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SetHints sh = hp.GetComponent<SetHints>();
        string msg = input.text;
        input.text = "";
        string s = transform.parent.GetComponent<InputPanelCon>().msg;
        switch(s)
        {
            case "Hint 1":
                sh.hints[0] = msg;
                break;
            case "Hint 2":
                sh.hints[1] = msg;
                break;
            case "Hint 3":
                sh.hints[2] = msg;
                break;
        }

        transform.parent.gameObject.SetActive(false);

    }
}
