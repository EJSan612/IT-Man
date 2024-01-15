using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float xRange;
    public float yRange;

    private bool movingRight = true;
    private Animator animator;
    private bool isStopped;

    [SerializeField] private float damageToPlayer = 0.15f;

    private Rigidbody2D eBody;

    private AudioSource SFX_src;
    public AudioClip SFX_Shoot;

    public float attackRange = 1f;
    public LayerMask enemyLayer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        SFX_src= GetComponent<AudioSource>();
        eBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance < xRange && distance < yRange)
        {
            Debug.Log("Detected Player");
            isStopped = true;
            animator.SetBool("playerDetected", true);

            // Determine the direction of the player relative to the NPC
            if (target.position.x > transform.position.x)
            {
                movingRight = true;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                movingRight = false;
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            isStopped = false;
            animator.SetBool("playerDetected", false);
            if (!isStopped)
            {
                transform.Translate(Vector2.right * (movingRight ? 1 : -1) * speed * Time.deltaTime);
            }
        }
    }

    void OnAnimatorMove()
    {
        // Check if the "Shoot" animation is playing
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
        {
            eBody.isKinematic = true;
            Health playerHealth = target.GetComponent<Health>();
            playerHealth.putDamage(damageToPlayer);
            // Play the audio clip
            if (!SFX_src.isPlaying)
            {
                SFX_src.clip = SFX_Shoot;
                SFX_src.Play();
            }
        }
        else
        {
            eBody.isKinematic = false;
            // Stop the audio clip
            if (SFX_src.isPlaying && SFX_src.clip == SFX_Shoot)
            {
                SFX_src.Stop();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
