using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelScripts : MonoBehaviour
{
    public void PassLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        print(currentLevel);
        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }
    }
}
