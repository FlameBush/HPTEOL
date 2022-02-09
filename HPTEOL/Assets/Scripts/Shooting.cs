using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject basicSpell;
    [SerializeField] private GameObject secondSpell;
    [SerializeField] private GameObject thirdSpell;

    private const int maxBullets = 2;
    private int currentBulletNumber;

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetButtonDown("Fire1"))
        {
            //Shoot();
            Instantiate<GameObject>(basicSpell, firePoint.position, firePoint.rotation);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            //Shoot();
            Instantiate<GameObject>(secondSpell, firePoint.position, firePoint.rotation);
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            //Shoot();
            Instantiate<GameObject>(thirdSpell, firePoint.position, firePoint.rotation);
        }
    }

    private void Shoot ()
    {
        Instantiate<GameObject>(basicSpell, firePoint.position, firePoint.rotation);
    }
}
