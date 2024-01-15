using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class agentPrompt : MonoBehaviour
{
    public GameObject promptUI;
    public GameObject gameAssets;
    public TextMeshProUGUI promptText;

    private Coroutine displineCoroutine;
    private bool canContinue = false;
    [SerializeField] private float typingSpeed = 0.1f;

    public static bool isPromptActive = false;

    GameObject continueGame;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        promptUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canContinue)
            continueGame.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool tag_Player = collision.gameObject.CompareTag("Player") ? true : false;
        if (tag_Player)
        {
            Image agentImg;
            string guide_name = gameObject.name;
            string prompt = "";
            string guide_img_go = "";
            if(guide_name == "IntroHelper")
            {
                guide_img_go = "pxlwoman";
                prompt = "I know that you have been fired by your team manager and I also" +
                    " know that you are capable of fixing the damages that have been done by your anonymous co-worker." +
                    " Fight your way back and obtain your team leaders trust!";
            }
            else if (guide_name == "AgentHelper")
            {
                guide_img_go = "pxlwoman";
                prompt = "Now that you have gone passed the first level. " +
                    "Your name is now all over the place, you have to be very careful. " +
                    "Police will now actively look for you.";

            }
            else if (guide_name == "AgentHelper2")
            {
                guide_img_go = "agent2";
                prompt = "I believe that you have done nothing wrong with our system. Hide your way into the woods and protect yourselves!";
            }else if(guide_name == "AgentHelper3")
            {
                guide_img_go = "pxlwoman";
                prompt = "You have to go back to the city, I've heard that they are planning something dangerous!";
            }

            promptText.text = prompt;
            displayPrompt();
            agentImg = GameObject.Find("Agent").GetComponent<Image>();
            agentImg.sprite = Resources.Load<Sprite>(guide_img_go);
        }
    }

    private void displayPrompt()
    {
        isPromptActive = true;
        promptUI.SetActive(true);
        gameAssets.SetActive(false);


        continueGame = GameObject.Find("Proceed");
        continueGame.SetActive(false);

        if (displineCoroutine != null)
        {
            StopCoroutine(displineCoroutine);
        }

        displineCoroutine = StartCoroutine(loadGuide(promptText.text));
    }

    private IEnumerator loadGuide(string line)
    {
        isPromptActive = true;
        promptText.text = "";
        canContinue = false;
        foreach (char letter in line.ToCharArray())
        {
            promptText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinue = true;
    }
}
