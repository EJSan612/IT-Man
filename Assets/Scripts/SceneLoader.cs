using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene()
    {
        SceneManager.LoadScene("Level_Menu");
        PlayerPrefs.SetString("level_one", "false");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
