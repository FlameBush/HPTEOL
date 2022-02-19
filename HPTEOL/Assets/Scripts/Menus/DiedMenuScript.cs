using UnityEngine;
using UnityEngine.UI;

public class DiedMenuScript : MonoBehaviour
{
    [SerializeField] Image DiedMenu;

    public void DisplayDiedMenu()
    {
        if (DiedMenu.gameObject.activeSelf != true)
        {
            DiedMenu.gameObject.SetActive(true);
        }
    }

    public void HideDiedMenu()
    {
        DiedMenu.gameObject.SetActive(false);
    }
}
