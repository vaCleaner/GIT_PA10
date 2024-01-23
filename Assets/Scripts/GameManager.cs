using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    private int Score = 0;
    private bool isgame;

    void Start()
    {
        isgame = false;
        thisManager = this;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return) && isgame == false)
        {
          StartGame();
        }


        if (Time.timeScale == 0 && isgame == true && Input.GetKeyDown(KeyCode.Return))
        {
            restart();
        }
    }

    public void UpdateScore(int value)
    {
        Score += value;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";

    }
    private void restart()
    {
        
        SceneManager.LoadScene("GameOver");

    }
    public void GameOver()
    {
        isgame = true;
        Time.timeScale = 0;
        restart();
        Txt_Message.text = "GAMEOVER! \nPRESS ENTER TO RESTART GAME.";
        Txt_Message.color = Color.red;
    }
}
