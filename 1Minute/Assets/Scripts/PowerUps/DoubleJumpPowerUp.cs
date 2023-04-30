using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    void Update()
    {
        if(PlayerMovement.instance.doubleJumpUnlocked == true)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerMovement.instance.doubleJumpUnlocked = true;
            Destroy(gameObject);
        }
    }
}
