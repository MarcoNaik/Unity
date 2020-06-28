using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;
    public float speed;
    public int bulletDamage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed *Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
