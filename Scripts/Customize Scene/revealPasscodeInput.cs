using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealPasscodeInput : MonoBehaviour
{
    public GameObject passcodePanel;
    // Start is called before the first frame update

    void Awake()
    {
        passcodePanel.SetActive(false);
    }

    public void showPasscodePanel()
    {
        passcodePanel.SetActive(true);
    }
}
