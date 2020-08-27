using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public LoadPanels lp;
    public void LoadScene(int id)
    {
        StartCoroutine(LoadAsyncScene(id));
    }

    IEnumerator LoadAsyncScene(int id)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(id);
        asyncLoad.allowSceneActivation = false;
        yield return (asyncLoad.progress > 0.9f);
        lp.open = false;
        StartCoroutine(Loaded(asyncLoad));
    }

    IEnumerator Loaded(AsyncOperation sync)
    {
        yield return new WaitForSeconds(2);
        sync.allowSceneActivation = true;
    }
}
