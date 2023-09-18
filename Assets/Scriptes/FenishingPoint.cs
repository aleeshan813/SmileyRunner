using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FenishingPoint : MonoBehaviour
{
    [SerializeField] int Level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Flag"))
        {
            NextLevel(Level);
        }
    }
    void NextLevel(int level)
    {
        AudioManager.instance.PlaySFX("GameWin");
        string levelName = "level_" + level;
        SceneManager.LoadScene("Level_" + level.ToString());
        UnlockNewLevel(Level);
    }

    void UnlockNewLevel(int level)
    {
        int nextLevelIndex = level;

        if (nextLevelIndex > PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", nextLevelIndex);
            PlayerPrefs.SetInt("UnlockedLevel", nextLevelIndex);
            PlayerPrefs.DeleteKey("ReachedIndex");
            PlayerPrefs.Save();
        }
    }

}
