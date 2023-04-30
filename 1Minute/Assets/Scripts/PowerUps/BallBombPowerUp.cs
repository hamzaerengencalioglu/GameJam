using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBombPowerUp : MonoBehaviour
{
    void Update()
    {
        if(BallController.instance.ballBombUnlocked == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            BallController.instance.ballBombUnlocked = true;
        }
    }
}

//RealMoney ballBombObject;
//public bool ballBombBool;
//private void Start()
//{

//    ballBombObject = FindObjectOfType<RealMoney>();

//    //  ballBombBool = ballBombObject.GetComponent<RealMoney>().ballBombUnlockedload;

//}

//private void Update()
//{

//    if (!(ballBombObject.GetComponent<RealMoney>().ballBombUnlockedload))
//    {
//        BallController.instance.ballBombUnlocked = true;
//        Debug.Log("ben cal?s?yom ha");
//    }
//}
//private void OnTriggerEnter2D(Collider2D other)
//{
//    if (other.tag == "Player")
//    {
//        Destroy(gameObject);
//        BallController.instance.ballBombUnlocked = true;




//    }
//}