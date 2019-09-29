using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    public GameObject GameMsgPanel;

    public void SceneSwitcher()
    {
        SceneManager.LoadScene(1);
        GameMsgPanel.SetActive(false);
    }
}
