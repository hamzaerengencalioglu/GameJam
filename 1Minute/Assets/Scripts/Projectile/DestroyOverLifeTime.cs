using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverLifeTime : MonoBehaviour
{
    public float lifeTime = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
