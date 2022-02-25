using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static int levelsUnlocked;

    [SerializeField] Button[] levelsymbols = new Button[5];

    private void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < levelsymbols.Length; i++)
        {
            levelsymbols[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            levelsymbols[i].interactable = true;
        }
    }

    private void Update()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked");
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
        PlayerPrefs.DeleteKey("levelsUnlocked");
        Start();
    }
}
