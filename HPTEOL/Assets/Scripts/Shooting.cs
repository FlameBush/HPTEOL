using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    private const int maxBullets = 2;
    private int currentBulletNumber;

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot ()
    {
        Instantiate<GameObject>(bullet, firePoint.position, firePoint.rotation);
    }
}
