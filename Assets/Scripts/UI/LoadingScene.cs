using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{ 
    public Image loadingCircleBar;
    public Text textLoading;
    public GameObject generalButton;

    public void LoadScene(int sceneId)
    {
        loadingCircleBar.gameObject.SetActive(true);
        generalButton.gameObject.SetActive(false);
        textLoading.text = "Loading...";
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);


        if(operation.isDone)
        {
            yield return null;
        }
    } 
    
}
