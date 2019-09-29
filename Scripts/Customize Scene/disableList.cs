using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableList : MonoBehaviour
{
   public void disableLists()
    {
        GameObject list = GameObject.Find("List");
        list.SetActive(false);
    }
}
