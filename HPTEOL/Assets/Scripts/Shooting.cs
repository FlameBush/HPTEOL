using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject basicSpell;
    [SerializeField] private GameObject secondSpell;
    [SerializeField] private GameObject thirdSpell;

    [SerializeField] private Image abilityImage1;
    [SerializeField] private Image abilityImage2;
    [SerializeField] private Image abilityImage3;

    private const int maxBullets = 2;
    private int currentBulletNumber;
    private bool usedAbility;

    // Update is called once per frame
    void Update()
    {
        if (!EscapeMenuScript.escapeScreenIsActive)
        {
            if (Input.GetButtonDown("Fire1") && !usedAbility)
            {
                Shoot(basicSpell);
                AnimatingAbilitySymbol(abilityImage1);
                StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImage1, 0.25f));
            }
            else if (Input.GetButtonDown("Fire2") && !usedAbility)
            {
                Shoot(secondSpell);
                AnimatingAbilitySymbol(abilityImage2);
                StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImage2, 1f));
            }
            else if (Input.GetButtonDown("Fire3") && !usedAbility)
            {
                Shoot(thirdSpell);
                AnimatingAbilitySymbol(abilityImage3);
                StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImage3, 2f));
            }
        }
    }
    // need delay ----- check StartCoroutine
    private void AnimatingAbilitySymbol(Image abilityImage)
    {
        abilityImage.color = new Color32(255, 255, 225, 150);
        abilityImage.transform.localScale = new Vector2(0.8f, 0.8f);
        usedAbility = true;
    }

    private IEnumerator AnimatingAbilitySymbolBackwards(Image abilityImage, float time)
    {
        yield return new WaitForSeconds(time);

        abilityImage.color = new Color32(255, 255, 225, 70);
        abilityImage.transform.localScale = new Vector2(1, 1);
        usedAbility = false;
    }

    private void Shoot (GameObject prefab)
    {
        Instantiate<GameObject>(prefab, firePoint.position, firePoint.rotation);
    }
}
