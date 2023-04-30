using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPowerUp : MonoBehaviour
{
    void Update()
    {
        if(ParentScript.instance.ballUnlocked == true)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            ParentScript.instance.ballUnlocked = true;
        }
    }
}
