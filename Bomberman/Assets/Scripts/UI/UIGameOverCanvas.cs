using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverCanvas : MonoBehaviour
{
    Button playAgainButton;
    Button quitButton;
    public static bool playAgain = false;
    void Start()
    {
        playAgainButton = transform.Find("Panel").Find("PlayAgainButton").GetComponent<Button>();
        quitButton = transform.Find("Panel").Find("QuitButton").GetComponent<Button>();
        playAgainButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(UIMenuCanvas.Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAgain()
    {
        playAgain = true;
    }
}
