using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static int levelsUnlocked {
        get
        {
            return PlayerPrefs.GetInt("levelsUnlocked", 1);
        }
        set
        {   
            PlayerPrefs.SetInt("levelsUnlocked", value);
        }
    }

    [SerializeField] Button[] levelsymbols = new Button[5];


    private void Start()
    {
        for (int i = 0; i < levelsymbols.Length; i++)
        {

            levelsymbols[i].interactable = false;
        }

        for (int i = 0; i <= levelsUnlocked - 1; i++)
        {
            levelsymbols[i].interactable = true;
        }
    }

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="levelIndex"></param>
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    /// <summary>
    /// Wipes all level unlocked data
    /// </summary>
    public void WipeData()
    {
        levelsUnlocked = 1;
        Start();
    }
}
