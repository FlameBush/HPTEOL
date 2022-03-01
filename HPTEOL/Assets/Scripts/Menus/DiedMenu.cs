using UnityEngine;

public class DiedMenu : MonoBehaviour
{
    private GameObject DeathMenu;

    private void Start()
    {
        DeathMenu = GameObject.Find("GameCanvas").transform.Find("Died Menu").gameObject;
    }

    public void DisplayDiedMenu()
    {
        if (DeathMenu.gameObject.activeSelf != true)
        {
            DeathMenu.SetActive(true);
        }
    }

    public void HideDiedMenu()
    {
        DeathMenu.SetActive(false);
    }
}
