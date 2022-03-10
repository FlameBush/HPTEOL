using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cast : MonoBehaviour
{
    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject[] spells = new GameObject[3];
    [SerializeField] private Image[] abilityImages = new Image[3];
    
    private bool[] usedAbilityX = new bool[3];
    private bool[] selectedAbilityX = new bool[3];
    
    private PlayerMovement movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        abilityImages.SetValue(GameObject.Find("Spell1").GetComponent<Image>(), 0);
        abilityImages.SetValue(GameObject.Find("Spell2").GetComponent<Image>(), 1);
        abilityImages.SetValue(GameObject.Find("Spell3").GetComponent<Image>(), 2);
        for (int i = 0; i < usedAbilityX.Length; i++)
        {
            usedAbilityX[i] = false;
        }
    }

    [SerializeField] Image[] SelectImages;

    private void Update()
    {
        if (!EscapeMenu.escapeScreenIsActive)
        {
            Time.timeScale = 1;

            if (Input.GetButtonDown("Fire1"))
            {
                if (selectedAbilityX[0] && !usedAbilityX[0])
                {
                    Shoot(spells[0]);
                    AnimatingAbilitySymbol(abilityImages[0]);
                    StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImages[0], 0.35f, 0));
                    usedAbilityX[0] = true;
                }
                if (selectedAbilityX[1] && !usedAbilityX[1])
                {
                    Shoot(spells[1]);
                    AnimatingAbilitySymbol(abilityImages[1]);
                    StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImages[1], 0.85f, 1));
                    usedAbilityX[1] = true;
                }
            }

            /*
            //Uncomment This to get the previous system up and Running
            //from Line 38-79
            //if (Input.GetButtonDown("Fire1") && !usedAbilityX[0])
            //{
            //    Shoot(spells[0]);
            //    AnimatingAbilitySymbol(abilityImages[0]);
            //    StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImages[0], 0.35f, 0));
            //    usedAbilityX[0] = true;
            //}
            //else if (Input.GetButtonDown("Fire2") && !usedAbilityX[1])
            //{
            //    Shoot(spells[1]);
            //    AnimatingAbilitySymbol(abilityImages[1]);
            //    StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImages[1], 0.85f, 1));
            //    usedAbilityX[1] = true;
            //}
            //else if (Input.GetButtonDown("Fire3") && !usedAbilityX[2])
            //{
            //    Shoot(spells[2]);
            //    AnimatingAbilitySymbol(abilityImages[2]);
            //    StartCoroutine(AnimatingAbilitySymbolBackwards(abilityImages[2], 1.25f, 2));
            //    usedAbilityX[2] = true;
            //}
            */
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("1 Pressed");
                for (int i = 0; i < selectedAbilityX.Length; i++)
                {
                    if (i == 0)
                    {
                        selectedAbilityX[i] = true;
                    }
                    else
                    {
                        selectedAbilityX[i] = false;
                    }
                }
                if (SelectImages[0].enabled == true)
                {
                    SelectImages[0].enabled = false;
                    SelectImages[1].enabled = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("1 Pressed");
                for (int i = 0; i < selectedAbilityX.Length; i++)
                {
                    if (i == 1)
                    {
                        selectedAbilityX[i] = true;
                    }
                    else
                    {
                        selectedAbilityX[i] = false;
                    }
                }
                if (SelectImages[1].enabled == true)
                {
                    SelectImages[1].enabled = false;
                    SelectImages[0].enabled = true;
                }
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
        abilityImage.transform.DOScale(new Vector2(0.8f, 0.8f), 0.125f);
        abilityImage.transform.GetChild(2).transform.DOLocalMoveY(-125, 0);
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
        abilityImage.transform.DOScale(Vector2.one, 0.3f).SetEase(Ease.InBack);
        abilityImage.transform.GetChild(2).transform.DOLocalMoveY(0, time);
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