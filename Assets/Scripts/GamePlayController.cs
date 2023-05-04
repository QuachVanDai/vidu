using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    public Score sc;
    void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    [SerializeField]
    private GameObject pausePanel,gameOverPanel,pauseButton;
   public void PauseGamebutton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGameButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void planeDieShowPanel()
    {
        pauseButton.SetActive(false);
        gameOverPanel.SetActive(true);
        Score.score1 = 0;
       playerPlane.instance.currentHelth =playerPlane.instance.maxHealth;
       playerPlane.instance.Plane.SetActive(false);

    }
    public void ReStartButton()
    {
        pauseButton.SetActive(true);
        gameOverPanel.SetActive(false);
        Application.LoadLevel("MainMenu");
    }
}
