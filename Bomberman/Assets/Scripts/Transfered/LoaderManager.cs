using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoaderManager : MonoBehaviourSingleton<LoaderManager>
{
    public float loadingProgress;
    public bool fakeLoad;
    public float timeLoading;
    public float minTimeToLoad = 2;
    public UILoadingScreen uiLoadingScreen;
    
    void Start()
    {
    
    }
    
    void FakeLoad()
    {
        uiLoadingScreen.SetVisible(true);
        StartCoroutine(AsynchronousFakeLoad());
    }
    
    public void LoadScene(int scene)
    {
        if (fakeLoad)
        {
            StartCoroutine(AsynchronousLoadWithFake(scene));
        }
        else
        {
            StartCoroutine(AsynchronousLoad(scene));
        }
    }
    
    public IEnumerator AsynchronousFakeLoad()
    {
        loadingProgress = 0;
    
        yield return null;
    
        while (loadingProgress < 1)
        {
    
            loadingProgress += 0.01f;
    
            if (loadingProgress >= 1)
            {
                loadingProgress = 1;
            }
    
    
            yield return null;
        }
    }
    
    IEnumerator AsynchronousLoad(int scene)
    {
        loadingProgress = 0;
    
        yield return null;
    
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;
    
        while (!ao.isDone)
        {
            loadingProgress = ao.progress + 0.1f;
    
            // Loading completed
            if (ao.progress >= 0.9f)
            {
                ao.allowSceneActivation = true;
            }
    
            yield return null;
        }
    }
    
    IEnumerator AsynchronousLoadWithFake(int scene)
    {
        uiLoadingScreen.SetVisible(true);
        loadingProgress = 0;
        timeLoading = 0;
        yield return null;
    
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;
    
        while (!ao.isDone)
        {
            timeLoading += Time.deltaTime;
            loadingProgress = ao.progress + 0.1f;
            loadingProgress = loadingProgress * timeLoading / minTimeToLoad;
    
            // Loading completed
            if (loadingProgress >= 1)
            {
                ao.allowSceneActivation = true;
                uiLoadingScreen.SetVisible(false);
            }
    
            yield return null;
        }
    }  
}