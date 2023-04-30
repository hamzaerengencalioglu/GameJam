using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float damage;

    void Start()
    {
        Vector3 direction = transform.position - ParentScript.instance.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.right * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerMovement.instance.getDamage(damage);
        }

        Destroy(gameObject);
    }
}
