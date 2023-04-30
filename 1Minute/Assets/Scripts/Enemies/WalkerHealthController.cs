using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerHealthController : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth = 50;

    public GameObject walker;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            currentHealth = 0;

            gameObject.SetActive(false);
        }
    }
}
