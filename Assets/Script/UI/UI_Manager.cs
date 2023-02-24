using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]bool Isplaying;
    [SerializeField] GameObject _pausePanel;
    private void Awake()
    {
        Isplaying = true;
    }
    public void Play() //For start game
    {
        SceneManager.LoadScene("Game scene");
        Time.timeScale = 1;
    }
    public void Quit() //For quiting application
    {
        Application.Quit();
    }

    public void PlayAgain()     //For restart game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void MainMenu() //For main menu
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PauseResume()
    {
        Isplaying = !Isplaying;
        _pausePanel.SetActive(!Isplaying);
        Time.timeScale = Isplaying ? 1 : 0;

    }
}
