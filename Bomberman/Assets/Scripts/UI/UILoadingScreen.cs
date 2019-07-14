using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoadingScreen : MonoBehaviourSingleton<UILoadingScreen>
{
    public Text loadingText;

    public void SetVisible(bool show)
    {
        gameObject.SetActive(show);
    }

    public void Update()
    {
        int loadingVal = (int)(LoaderManager.Get().loadingProgress * 100);
        loadingText.text = loadingVal + "%";
        if (LoaderManager.Get().loadingProgress >= 1)
            SetVisible(false);
    }
}
