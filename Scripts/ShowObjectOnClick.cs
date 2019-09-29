using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectOnClick : MonoBehaviour
{
    public void ShowByObject(GameObject target)
    {
        target.SetActive(true);
    }
}
