using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetMainMenu : MonoBehaviour
{
    public void returnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMainMenu");
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
