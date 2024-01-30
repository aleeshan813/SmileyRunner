using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{ 
    public void GameOver(int level)
    {
        string levelName = "level_" + level;
        SceneManager.LoadScene("Level_" + level.ToString());
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
