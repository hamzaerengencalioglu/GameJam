using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSceneTurnScript : MonoBehaviour
{
    RealMoney RealMoneyObject;

    public int MainSceneQueue;

    public float healtCost;
    public float extraHealt;

    public float bulletCost;
    public int extraBossDamage;
    public float extraBulletDamage;

    void Start()
    {
        RealMoneyObject = FindObjectOfType<RealMoney>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(MainSceneQueue);

        }

        if (    (Input.GetKeyDown(KeyCode.Keypad1)) || Input.GetKeyDown(KeyCode.Alpha1) &&  RealMoneyObject.GetComponent<RealMoney>().realGold >= healtCost)

        {


            RealMoneyObject.GetComponent<RealMoney>().realGold -= healtCost;

            RealMoneyObject.GetComponent<RealMoney>().playerHealthStore += extraHealt;
        }
    
        if( (Input.GetKeyDown(KeyCode.Keypad2)) || Input.GetKeyDown(KeyCode.Alpha2) &&  RealMoneyObject.GetComponent<RealMoney>().realGold >= bulletCost  )

        {

            RealMoneyObject.GetComponent<RealMoney>().realGold -= bulletCost;


            RealMoneyObject.GetComponent<RealMoney>().bulletDamageStore += extraBulletDamage;
            
            RealMoneyObject.GetComponent<RealMoney>().bulletBossDamageStore += extraBossDamage;


        }

    }
}


