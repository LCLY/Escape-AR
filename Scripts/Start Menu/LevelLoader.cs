using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public float timeLimit = 5;
    float timer = 0;
    float progressPercentage = 0;
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        //whenever call this coroutine, load scene asynchronously
        //while loop run until the process is done
        //wait for a frame until its doing it again
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            //float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = timer;
            //progressText.text = (progress * 100).ToString("F0") + "%";
            /*progressPercentage = ((timer / timeLimit) * 100);
            if (progressPercentage <= 101)
            {
                progressText.text = progressPercentage.ToString("F0") + "%";
            }*/
                
            //Debug.Log(progress);
            yield return null;
        }
    }

    private void Update()
    {
        if (timer < timeLimit)
        {
            timer += Time.deltaTime;
        }       
    }
}

