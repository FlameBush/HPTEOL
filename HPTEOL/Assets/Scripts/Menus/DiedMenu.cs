using UnityEngine;

public class DiedMenu : MonoBehaviour
{

    [SerializeField] GameObject DeathMenu;

    public void DisplayDiedMenu()
    {
        DeathMenu.SetActive(true);
    }

    public void HideDiedMenu()
    {
        DeathMenu.SetActive(false);
    }
}
