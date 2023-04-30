using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using TMPro;
public class Money : MonoBehaviour
{
    RealMoney RealMoneyObject;

    public float gold ;

    public float RealMoneyCome;

    public float jumperGold = 10f;

    public GameObject heroObject;

    public GameObject[] coinObject  ;
  

    public GameObject [] objectJumper;

    // Enemy 0
    public bool isDeadJumper = false;
    public bool  isDestroyedJumper = false;
    bool waitEarn = true;
    //Enemy 1
    public bool isDeadJumper1 = false;
    public bool isDestroyedJumper1 = false;
    bool waitEarn1 = true;
    //Enemy 2
    public bool isDeadJumper2 = false;
    public bool isDestroyedJumper2 = false;
    bool waitEarn2 = true;
    
    //TextMeshPro
    public TextMeshProUGUI coinstext;

    void Start() 
    {
      StartCoroutine(Countdown60());

        RealMoneyObject = FindObjectOfType<RealMoney>();

        RealMoneyCome = RealMoneyObject.GetComponent<RealMoney>().realGold;

    }

     void Update()
    {
        coinstext.text = RealMoney.Instance.realGold.ToString();
  
        
        EarnCoinJumper();
        EarnCoinJumper1();
        EarnCoinJumper2();


    }

    IEnumerator Countdown60()
    {
        yield return new WaitForSeconds(60f);

        heroObject.GetComponent<PlayerMovement>().playerHealth = 0;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    //  E N E M I E S
    IEnumerator isDeadJumperWait()   // Jumper destroy two seconds after dead.
    {
      
    
        coinObject[0].SetActive(true);


        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);

        isDestroyedJumper = true;

        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

    }

    void EarnCoinJumper()
    {
       
        if (!isDeadJumper)
        {
            isDeadJumper = objectJumper[0].GetComponent<JumperEnemyMove>().isDeadEnemy;
        }
        else
        {

        }

        if (isDeadJumper &&  waitEarn && !isDestroyedJumper)
        {



            StartCoroutine(isDeadJumperWait());

        }
        if (isDestroyedJumper && waitEarn)
        {
            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
            waitEarn = false;
        }


    }

    IEnumerator isDeadJumperWait1()   
    {
        coinObject[0].SetActive(true);


        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);

        isDestroyedJumper1 = true;
        
        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

    }
    void EarnCoinJumper1()
    {

        if (!isDeadJumper1)
        {
            isDeadJumper1 = objectJumper[1].GetComponent<JumperEnemyMove>().isDeadEnemy;
        }
        else
        {

        }

        if (isDeadJumper1 &&  waitEarn1 && !isDestroyedJumper1)
        {



            StartCoroutine(isDeadJumperWait1());

        }
        if (isDestroyedJumper1 && waitEarn1)
        {
            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
            waitEarn1 = false;
        }


    }

    IEnumerator isDeadJumperWait2()   
    {
        coinObject[0].SetActive(true);   
        

        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);
        isDestroyedJumper2 = true;

        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

    }
    void EarnCoinJumper2()
    {

        if (!isDeadJumper2)
        {
            isDeadJumper2 = objectJumper[2].GetComponent<JumperEnemyMove>().isDeadEnemy;
        }
        else
        {

        }

        if (isDeadJumper2 &&  waitEarn2 && !isDestroyedJumper2)
        {



            StartCoroutine(isDeadJumperWait2());

        }
        if (isDestroyedJumper2 && waitEarn2)
        {
         
            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
            waitEarn2 = false;
        }


    }




}
