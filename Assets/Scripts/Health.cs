using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float current_Health = 0;
    public int max_Health = 100;
    public float regenRate = 5f;
    public Animator animator;

    private AudioSource entity_au_src;
    public AudioClip entity_au_death;

    //public GameObject condition;

    // Start is called before the first frame update
    void Start()
    {
        entity_au_src= GetComponent<AudioSource>();
        current_Health = max_Health;
        //condition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        regenHealth();
    }

    public void regenHealth()
    {
        if(current_Health < max_Health)
        {
            current_Health += regenRate * Time.deltaTime;
        }else if(current_Health > max_Health)
        {
            current_Health = max_Health;
        }
    }

    public void putDamage(float d)
    {
        string elTag = transform.gameObject.tag;
        if (current_Health <= max_Health)
        {
            current_Health -= d;
            if (current_Health <= 0 && elTag == "Player")
            {
                //animator.SetTrigger("Death");
                //Destroy(gameObject);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if(current_Health <= 0 && elTag == "Enemy")
            {
                BoxCollider2D enemyR2D = GetComponent<BoxCollider2D>();
                Destroy(enemyR2D);
                bool f = entity_au_src.clip.name == "fire" ? true : false;
                if (f) { entity_au_src.Stop(); }
                if (!entity_au_src.isPlaying) {
                    entity_au_src.clip = entity_au_death;
                    animator.SetBool("playerDetected", false);
                    StartCoroutine(PlayAudioThenDestroy(entity_au_src.clip.length));
                }
            }
        }
    }

    #region Delays

    IEnumerator PlayAudioThenDestroy(float audioLength)
    {
        EnemyFollow x = GetComponent<EnemyFollow>();
        Destroy(x);
        //animator.SetBool("playerDetected", false);
        animator.SetTrigger("policeDead"); 
        entity_au_src.Play();
        yield return new WaitForSeconds(audioLength);
        Destroy(gameObject);
    }

    #endregion
    /*public void putDamage( int d, Collision2D q )
    {
        if(current_Health <= max_Health && current_Health != 0)
        {
            current_Health -= d;
            if(current_Health <= 0)
            {
                if (q.gameObject.CompareTag("Player"))
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
                else
                {
                    Destroy(q.gameObject);
                }
            }
        }
    }*/
}
