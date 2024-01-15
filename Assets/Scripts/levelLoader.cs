using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        checkLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("StartMainMenu");
    }

    public void loadLevel()
    {
        TextMeshProUGUI btnText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        string levelPicked = btnText.text;
        try
        {
            SceneManager.LoadScene("SceneLevel" + levelPicked);
        }catch(UnityException ex)
        {
            SceneManager.LoadScene("StartMainMenu");
        }
    }

    private void checkLevel()
    {
        List<string> lvlAvailable = new List<string>();
        for(int i=0; i<7; i++)
        {
            int x = i + 1;
            string lvl = "";
            switch(x)
            {
                case 1:
                    lvl = "one";
                    break;
                case 2:
                    lvl = "two";
                    break;
                case 3:
                    lvl = "three";
                    break;
                case 4:
                    lvl = "four";
                    break;
                case 5:
                    lvl = "five";
                    break;
                case 6:
                    lvl = "six";
                    break;
                case 7:
                    lvl = "seven";
                    break;
            }

            if (PlayerPrefs.HasKey("level_" + lvl) && (PlayerPrefs.GetString("level_"+lvl) == "false" || PlayerPrefs.GetString("level_" + lvl) == "true"))
            {
                string theLevel = "level_" + lvl;
                lvlAvailable.Add(theLevel);
            }
            else
            {
                GameObject button = GameObject.Find("btn_lvl"+UppercaseFirstLetter(lvl));
                Button btn = button.GetComponent<Button>();
                btn.interactable = false;
                
            }
        }
    }
    public string UppercaseFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1);
    }
}
