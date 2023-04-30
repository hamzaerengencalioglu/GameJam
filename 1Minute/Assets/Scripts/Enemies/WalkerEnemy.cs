using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Rigidbody2D rb;
    public Animator animator;

    public float waitAtPoints, moveSpeed;
    private float waitCounter;
    private int patrolIndex;

    public float damageToPlayer = 5f;

    public float jumpForce;

    void Start()
    {
        waitCounter = waitAtPoints;

        foreach(Transform pPoint in patrolPoints)
        {
            pPoint.SetParent(null);
        }
    }

    void Update()
    {
        if(Mathf.Abs(transform.position.x - patrolPoints[patrolIndex].position.x) > .2f)
        {
            if(transform.position.x > patrolPoints[patrolIndex].position.x)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                transform.localScale = Vector3.one;
            }
            else
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            if(transform.position.y < patrolPoints[patrolIndex].position.y - .5f && rb.velocity.y < .1f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);

            waitCounter -= Time.deltaTime;

            if(waitCounter <= 0)
            {
                waitCounter = waitAtPoints;

                patrolIndex++;

                if(patrolIndex >= patrolPoints.Length)
                {
                    patrolIndex = 0;
                }
            }
        }

        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerMovement.instance.getDamage(5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerMovement.instance.getDamage(damageToPlayer);
        }
    }
}
