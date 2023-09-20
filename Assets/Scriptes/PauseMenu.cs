using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PausPanel;
    [SerializeField] GameObject VolumePanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void volume()
    {
       VolumePanel.SetActive(true);
        PausPanel.SetActive(false);
    }

    public void Pause()
    {
        PausPanel.SetActive(!PausPanel.activeSelf);
        {
            Time.timeScale = 0f;
        }
    }
    public void Continue()
    {
       PausPanel.SetActive(false);
       Time.timeScale = 1.0f;
    }
}
