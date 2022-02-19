using System;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public int Currentinfo;
    private Animator playerAnimator;

    private void Start()
    {
        Time.timeScale = 0;
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        playerAnimator.SetBool("GameIsPaused", true);
    }

    private void Update()
    {
        if (this.gameObject.transform.GetChild(Currentinfo).gameObject.name == "end")
        {
            Time.timeScale = 1;
            playerAnimator.SetBool("GameIsPaused", false);
            this.gameObject.SetActive(false);
        }

        if (Input.anyKeyDown)
        {
            this.gameObject.transform.GetChild(Currentinfo).gameObject.SetActive(false);
            Currentinfo++;
            this.gameObject.transform.GetChild(Currentinfo).gameObject.SetActive(true);
        }
    }
}
