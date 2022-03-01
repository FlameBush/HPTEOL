using UnityEngine;

public class DiedMenuScript : MonoBehaviour
{
    private GameObject DiedMenu;

    private void Start()
    {
        DiedMenu = GameObject.Find("GameCanvas").transform.Find("Died Menu").gameObject;
    }

    public void DisplayDiedMenu()
    {
        if (DiedMenu.gameObject.activeSelf != true)
        {
            DiedMenu.SetActive(true);
        }
    }

    public void HideDiedMenu()
    {
        DiedMenu.SetActive(false);
    }
}
