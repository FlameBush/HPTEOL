using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Cast : MonoBehaviour
{
    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject[] spells = new GameObject[3];
    [SerializeField] private Image[] abilityImages = new Image[3];
    private bool[] usedAbilityX = new bool[3];

    private const int maxBullets = 2;
    private int currentBulletNumber;
    private PlayerMovement movement;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (!EscapeMenuScript.escapeScreenIsActive)
        {
            Time.timeScale = 1;
            if (Input.GetButtonDown("Fire1") && !usedAbilityX[0])
            {
                Shoot(spells[0]);
                AnimatingAbilitySymbol(abilityImages[0]);
                StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImages[0], 0.25f, 0));
                usedAbilityX[0] = true;
            }
            else if (Input.GetButtonDown("Fire2") && !usedAbilityX[1])
            {
                Shoot(spells[1]);
                AnimatingAbilitySymbol(abilityImages[1]);
                StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImages[1], 0.75f, 1));
                usedAbilityX[1] = true;
            }
            else if (Input.GetButtonDown("Fire3") && !usedAbilityX[2])
            {
                Shoot(spells[2]);
                AnimatingAbilitySymbol(abilityImages[2]);
                StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImages[2], 1.2f, 2));
                usedAbilityX[2] = true;
            }
        }
    }
    /// <summary>
    /// Implements what happen when an ability is used
    /// </summary>
    /// <param name="abilityImage"></param>
    /// <param name="time"></param>
    private void AnimatingAbilitySymbol(Image abilityImage)
    {
        LeanTween.init(800, 800);
        abilityImage.transform.LeanScale(new Vector2(0.8f, 0.8f), 0.125f);
        abilityImage.transform.GetChild(2).gameObject.LeanMoveLocalY(-125, 0);
    }

    /// <summary>
    /// Implement what happens when an ability "refills"
    /// </summary>
    /// <param name="abilityImage"></param>
    /// <param name="time"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    private IEnumerator AnimatingAbilitySymbolBackwards(Image abilityImage, float time, int i)
    {
        abilityImage.transform.LeanScale(Vector2.one, 0.3f).setEaseInBack();
        abilityImage.transform.GetChild(2).gameObject.LeanMoveLocalY(0, time);
        yield return new WaitForSeconds(time);

        usedAbilityX[i] = false;
    }

    /// <summary>
    /// Fires the "spell"
    /// </summary>
    /// <param name="spell"></param>
    private void Shoot(GameObject spell)
    {
        Instantiate<GameObject>(spell, firePoint.position, firePoint.rotation);
        movement.OnSpellShoot();
    }
}