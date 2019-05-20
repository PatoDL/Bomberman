using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UiController : MonoBehaviour
{
    Button playButton;
    // Start is called before the first frame update

    static UiController instance;
    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public static UiController Instance()
    {
        return instance;
    }

    void Start()
    {
        playButton = transform.Find("Panel").transform.Find("Play").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        playButton.onClick.AddListener(PlayGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
