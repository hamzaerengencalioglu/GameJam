using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthController : MonoBehaviour
{
    public static BossHealthController instance;
    public Slider healthSlider;


    public int currentHealth = 30;

    public BossBattle boss;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        healthSlider.maxValue = currentHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if(currentHealth <= 0)
        {
            currentHealth = 0;

            boss.EndBattle();
        }

        healthSlider.value = currentHealth;
    }
}

