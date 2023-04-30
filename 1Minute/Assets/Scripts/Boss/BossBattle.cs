using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    private SmoothCameraControl cam;
    public Transform camPoint;
    public float camSpeed;

    public float threshold1, threshold2;

    public float activeTime, fadeoutTime, inactiveTime;
    private float activeCounter, fadeCounter, inactiveCounter;

    public Transform[] spawnPoints;
    private Transform targetPoint;
    public Animator animator;
    public Transform boss;

    public float damageToPlayer = 10f;

    public float moveSpeed;

    void Start()
    {
        cam = FindObjectOfType<SmoothCameraControl>();
        cam.enabled = false;

        activeCounter = activeTime;
    }

    void Update()
    {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, camPoint.position, camSpeed * Time.deltaTime);

        if(BossHealthController.instance.currentHealth >threshold1)
        {
            if(activeCounter > 0)
            {
                activeCounter -= Time.deltaTime;

                if(activeCounter <= 0)
                {
                    fadeCounter = fadeoutTime;
                    animator.SetTrigger("vanish");
                }
            }
            else if(fadeCounter > 0)
            {
                fadeCounter -= Time.deltaTime;
                if(fadeCounter <= 0)
                {
                    inactiveCounter = inactiveTime;
                    boss.gameObject.SetActive(false);
                }
            }
            else if(inactiveCounter > 0)
            {
                inactiveCounter -= Time.deltaTime;

                if(inactiveCounter <= 0)
                {
                    boss.position = spawnPoints[ Random.Range(0, spawnPoints.Length)].position;
                    boss.gameObject.SetActive(true);
                    activeCounter = activeTime;
                }
            }
        }
        else
        {
            if(targetPoint == null)
            {
                targetPoint = boss;
                fadeCounter = fadeoutTime;
                animator.SetTrigger("vanish");
            }
            else
            {
                if (Vector3.Distance(boss.position, targetPoint.position) > 0.02f)
                {
                    boss.position = Vector3.MoveTowards(boss.position, targetPoint.position, moveSpeed * Time.deltaTime);

                    activeCounter -= Time.deltaTime;

                    if (Vector3.Distance(boss.position, targetPoint.position) < 0.02f)
                    {
                        fadeCounter = fadeoutTime;
                        animator.SetTrigger("vanish");
                    }
                }
                else if (fadeCounter > 0)
                {
                    fadeCounter -= Time.deltaTime;
                    if (fadeCounter <= 0)
                    {
                        inactiveCounter = inactiveTime;
                        boss.gameObject.SetActive(false);
                    }
                }
                else if (inactiveCounter > 0)
                {
                    inactiveCounter -= Time.deltaTime;

                    if (inactiveCounter <= 0)
                    {
                        boss.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

                        targetPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                        int whileBreaker = 0;
                        while(boss.position == targetPoint.position && whileBreaker < 100)
                        {
                            targetPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                            whileBreaker++;
                        }

                        boss.gameObject.SetActive(true);

                    }
                }
            }
        }
    }

    public void EndBattle()
    {
        gameObject.SetActive(false);
    }
}
