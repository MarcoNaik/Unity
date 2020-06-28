﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    
    private float shotCounter;

    public Transform firePoint;
    void Start()
    {
        isFiring = false;
        shotCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0f)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0f;
        }
    }
}
