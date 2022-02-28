using UnityEngine;
using UnityEngine.UI;

public class DiedMenuScript : MonoBehaviour
{
    [SerializeField] Image DiedMenu;

    private void Start()
    {
        if (GameObject.FindWithTag("DiedMenu") != null)
        {
            DiedMenu = GameObject.FindWithTag("DiedMenu").GetComponent<Image>();
        }
    }

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
