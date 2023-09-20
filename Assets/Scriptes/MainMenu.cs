using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
   /* [SerializeField] GameObject mainMenu;
    [SerializeField] TextMeshProUGUI pointstext;*/

   /* public void Start()
    {
        Points();
    }
*/
    public void levelSelector()
    {
        SceneManager.LoadScene(1);
    }
    public void Newgame()
    {
        // Reset the unlocked level to 1
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        PlayerPrefs.Save();
        AudioManager.instance.PlaySFX("GameWin");
        // Load the first level
        SceneManager.LoadScene("Level_1");
    }

    public void Volume()
    {

    }

    public void play()
    {
        // Retrieve the unlocked level from PlayerPrefs
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Ensure the unlocked level is within the valid range
        if (unlockedLevel >= 1 && unlockedLevel <= SceneManager.sceneCountInBuildSettings - 1)
        {
            // Load the unlocked level
            SceneManager.LoadScene("Level_" + unlockedLevel);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
