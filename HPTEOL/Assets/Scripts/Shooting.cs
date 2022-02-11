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
        if (!EscapeMenuScript.escapeScreenIsActive)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(basicSpell);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Shoot(secondSpell);
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                Shoot(thirdSpell);
            }
        }
    }

    private void Shoot (GameObject prefab)
    {
        Instantiate<GameObject>(prefab, firePoint.position, firePoint.rotation);
    }
}
