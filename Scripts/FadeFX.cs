using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeFX : MonoBehaviour
{
    public void DisplayMsg(string msg)
    {
        gameObject.SetActive(true);
        Text t = transform.Find("MenuMessage").gameObject.GetComponent<Text>();
        t.text = msg;
        Image i = GetComponent<Image>();
        StartCoroutine(FadeInOut(t, i));
    }
    IEnumerator FadeInOut(Text t, Image i)
    {
        t.CrossFadeAlpha(1, 1, false);
        i.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(1.5f);
        t.CrossFadeAlpha(0, 1, false);
        i.CrossFadeAlpha(0, 1, false);
        //yield return new WaitForSeconds(2);
        //gameObject.SetActive(false);
    }
}
