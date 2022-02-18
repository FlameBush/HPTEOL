using System;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public int Currentinfo;

    private void Update()
    {
        if (this.gameObject.transform.GetChild(Currentinfo).gameObject.name == "end")
        {
            this.gameObject.SetActive(false);
        }

        if (Input.anyKey)
        {
            this.gameObject.transform.GetChild(Currentinfo).gameObject.SetActive(false);
            Currentinfo++;
            this.gameObject.transform.GetChild(Currentinfo).gameObject.SetActive(true);
        }
    }
}
