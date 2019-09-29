using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class InputUsername : MonoBehaviour
{
    public InputField mainInputField;

    // Checks if there is anything entered into the input field.
    void LockInput(InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("Player: " + input.text);
            GameControl.control.username = input.text;
            GameControl.control.Save();
        }
        else if (input.text.Length == 0)
        {
            GameControl.control.username = "";
            GameControl.control.Save();
        }
    }

    public void Start()
    {
        //Adds a listener that invokes the "LockInput" method when the player finishes editing the main input field.
        //Passes the main input field into the method when "LockInput" is invoked
        GameControl.control.Load();
        mainInputField.onEndEdit.AddListener(delegate { LockInput(mainInputField); });
        if (GameControl.control.username != "")
        {
            mainInputField.text = GameControl.control.username;
        }
    }
}