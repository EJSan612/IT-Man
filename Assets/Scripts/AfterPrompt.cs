using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AfterPrompt : MonoBehaviour
{
    public GameObject ThePrompt;
    public Collider2D GuideCollider;
    public GameObject gameAssets;

    public void continueGame()
    {
        agentPrompt.isPromptActive = false;
        gameAssets.SetActive(true);
        ThePrompt.SetActive(false);
        GameObject.Destroy(GuideCollider);
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
