using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float timeToExplode = 0.7f;
    public GameObject explosion;

    public float explosionRadius = 2f;

    public LayerMask destructible;

    void Start()
    {
        
    }

    void Update()
    {
        timeToExplode -= Time.deltaTime;

        if(timeToExplode <= 0)
        {
            if(explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            Destroy(gameObject);

            Collider2D[] objectsToDestruct = Physics2D.OverlapCircleAll(transform.position, explosionRadius, destructible);

            if(objectsToDestruct.Length > 0)
            {
                foreach(Collider2D obj in objectsToDestruct)
                {
                    Destroy(obj.gameObject);
                }
            }
        }
    }
}
