using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuScript : MonoBehaviour
{
    private bool escapeScreenIsActive = false;
    public GameObject escapeScreen;

    // Update is called once per frame
    void Update()
    {
        if (escapeScreen != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !escapeScreenIsActive)
            {
                Time.timeScale = 0;
                escapeScreen.SetActive(true);
                escapeScreenIsActive = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && escapeScreenIsActive)
            {
                Time.timeScale = 1;
                escapeScreen.SetActive(false);
                escapeScreenIsActive = false;
            }
        }
    }
}
