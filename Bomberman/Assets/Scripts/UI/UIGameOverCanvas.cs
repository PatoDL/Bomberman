using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverCanvas : MonoBehaviour
{
    Button playAgainButton;
    public static bool playAgain = false;
    void Start()
    {
        playAgainButton = transform.Find("Panel").Find("PlayAgainButton").GetComponent<Button>();
        playAgainButton.onClick.AddListener(PlayAgain);
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
