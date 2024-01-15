using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelLoader : MonoBehaviour
{
    public void toNextLevel()
    {
        TextMeshProUGUI condition = GameObject.Find("Condition").GetComponent<TextMeshProUGUI>();
        string conditionText = condition.text;
        if(conditionText == "LEVEL COMPLETED!")
        {
            string current = SceneManager.GetActiveScene().name;
            if (current != "SceneLevel3")
            {
                Match match = Regex.Match(current, @"\d+");
                if (match.Success)
                {
                    int lvlNum = int.Parse(match.Value);
                    addAccomplished(lvlNum, "true");
                    addAccomplished((lvlNum + 1), "false");
                    try
                    {
                        SceneManager.LoadScene("SceneLevel" + (lvlNum + 1));
                    }
                    catch (ArgumentException ex)
                    {
                        SceneManager.LoadScene("StartMainMenu");
                    }
                }
            }
            else
            {
                SceneManager.LoadScene("StartMainMenu");
            }
        }
        else
        {
            SceneManager.LoadScene("Level_Menu");
        }
    }

    void addAccomplished(int c, string cond)
    {
        string level = "";
        string condition = cond;
        switch(c)
        {
            case 1:
                level = "level_one";
                break;
            case 2:
                level = "level_two";
                break;
            case 3:
                level = "level_three";
                break;
            case 4:
                level = "level_four";
                break;
            case 5:
                level = "level_five";
                break;
            case 6:
                level = "level_six";
                break;
            case 7:
                level = "level_seven";
                break;
        }
        PlayerPrefs.SetString(level, cond);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
