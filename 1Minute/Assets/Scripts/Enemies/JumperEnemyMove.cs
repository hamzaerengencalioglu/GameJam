using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumperEnemyMove : MonoBehaviour
{

    Rigidbody2D ManRigidBody;
    Animator KarakterAnimator;



    //Moving
    
    public float harekethizi;
    public float ziplamahizi;
    public float death_jump_hiz;
    //public float tekrarx;
    public bool yerdemi = false;
    public Transform ZeminPozisyonKontrol;
    public float ZeminCapKontrol;
    public int BirdahakiZiplanacakZaman, ZiplamaFrequency;
    public LayerMask ZeminKatmanKontrol;

    bool FaceRight = false;

    public int modal1;
    public int modalsonuc;

    public bool isDeadEnemy = false;


    //Damage
    public float enemyHealth;
    public float damageToPlayer;
    bool isColliderBusy = false;
    private bool tek_kullanma = true;

    public float yokolma_time;

    //Injuring
   public GameObject injurerPlayer;


    void Start()
    {
     
        ManRigidBody = GetComponent<Rigidbody2D>();
        KarakterAnimator = GetComponent<Animator>();

    }
    //  D
    //  A
    //  M
    //  A
    //  G
    //  E
    void Update()
    {

        if (tek_kullanma & enemyHealth <= 0)
        {
            StartCoroutine(dusman_death_ziplayis(yokolma_time));
            tek_kullanma = false;
            isDeadEnemy = true;

            KarakterAnimator.SetBool("isDeadEnemyAnim", isDeadEnemy);

        }
    }
    IEnumerator dusman_death_ziplayis(float yokolma_time)
    {
        //  GetComponent<dusmanhareket>().enabled = false;

        // death_jump();
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        //GetComponent<Animator>().enabled = false;


        yield return new WaitForSeconds(yokolma_time);
        Destroy(gameObject);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isColliderBusy)
        {
            isColliderBusy=true;
         
            if (injurerPlayer.activeSelf) 
            {
                collision.GetComponent<PlayerMovement>().getDamage(damageToPlayer);
            }
            StartCoroutine(flashInjure());
            
            //  collision.GetComponent<moving>().enabled = false;
            //  StartCoroutine(KarakterTepme_time(0f));
        }

    }

  


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            isColliderBusy = false;


            //collision.GetComponent<moving>().enabled = true;
        }


    }


    IEnumerator flashInjure()
    {
        injurerPlayer.GetComponent<SpriteRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        
        injurerPlayer.GetComponent<SpriteRenderer>().material.color = Color.white;

    }


    public void getDamage(float damageToEnemy)
    {
        if (enemyHealth - damageToEnemy >= 0)

        {
            enemyHealth -= damageToEnemy;
        }
        else

        {
            enemyHealth = 0;
           
        }

    }

//  M
//  O
//  V
//  I
//  N
//  G
    void FixedUpdate()
    {

        Modfonk();

        if (!isDeadEnemy)
        {

            if (yerdemi == false)
            {
                if (modalsonuc == 1)
                {
                    ManRigidBody.velocity = new Vector2(1f * harekethizi, ManRigidBody.velocity.y);     //bu da oluyor//
                                                                                                        // ManRigidBody.AddForce(new Vector2(tekrarx, 0f)); 
                }
                else if (modalsonuc == 0)
                {

                    ManRigidBody.velocity = new Vector2(-1f * harekethizi, ManRigidBody.velocity.y);
                    //  ManRigidBody.AddForce(new Vector2(-tekrarx  , 0f));
                }

            }

            else if (yerdemi)
            {

                ManRigidBody.velocity = new Vector2(0f, ManRigidBody.velocity.y); //0f de farkl? ManRigidBody.velocity.x


            }



        }
        else 
        {
            death_jump();
        }

        yerControl();





        if (ManRigidBody.velocity.x< 0 && FaceRight)
        {
            Faceturn();
        }
        else if (ManRigidBody.velocity.x>0 && !FaceRight)
        {


            Faceturn();


        }



        if (yerdemi && (BirdahakiZiplanacakZaman < Time.timeSinceLevelLoad))
        {
            BirdahakiZiplanacakZaman = (int)Time.timeSinceLevelLoad + ZiplamaFrequency;



            Zipla();


        }


    }
    void Faceturn()
    {

        FaceRight = !FaceRight;

        Vector3 boyut3 = transform.localScale;

        boyut3.x *= -1;

        transform.localScale = boyut3;


    }

    public void Zipla()
    {
        ManRigidBody.velocity = new Vector2(ManRigidBody.velocity.x, ziplamahizi);
        //   ManRigidBody.AddForce(new Vector2(ziplamayatayhiz, ziplamahizi));
    }
    public void death_jump()
    {
        ManRigidBody.velocity = new Vector2(0f, death_jump_hiz);

    }


    void yerControl()

    {

        yerdemi =  Physics2D.OverlapCircle(ZeminPozisyonKontrol.position, ZeminCapKontrol, ZeminKatmanKontrol);

        KarakterAnimator.SetBool("isground", yerdemi);
    }

    void Modfonk()
    {
        modalsonuc = BirdahakiZiplanacakZaman % modal1;



    }



}


