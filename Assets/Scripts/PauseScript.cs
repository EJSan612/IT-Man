using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject gamePause, kCount, hBar, gameResume;
    public TextMeshProUGUI buttonText;

    private bool isGamePaused = false;

    public void pauseGame()
    {
        if (buttonText.text == "||")
        {
            kCount.SetActive(false);
            hBar.SetActive(false);
            gamePause.SetActive(true);
            buttonText.text = ">";
            pauseButton.transform.SetParent(gamePause.transform);
            Time.timeScale = 0;
            isGamePaused = true;
        }
        else if(buttonText.text == ">")
        {
            buttonText.text = "||";
            gamePause.SetActive(false);
            kCount.SetActive(true);
            hBar.SetActive(true);
            pauseButton.transform.SetParent(gameResume.transform);
            Time.timeScale = 1;
            isGamePaused = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePaused)
        {
            // Clear all input data
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
