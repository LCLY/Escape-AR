using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectOnClick : MonoBehaviour
{
    public void HideByObject(GameObject target)
    {
        target.SetActive(false);
    }
}
