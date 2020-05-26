using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText;
    public int score;
    public bool start;
    public GameObject titleScreen;


    public void UpdateLives(int currentlives)
    {
        livesImageDisplay.sprite = lives[currentlives];
        Debug.Log(currentlives);
    }

    public void UpdateScore()
    {
        score += 10;

        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {

    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
        score = 0;
    }

    public void HideTitleScreen()
    {
        scoreText.text = "Score: ";
        titleScreen.SetActive(false);
    }

    public void ResumePlay(){
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.ResumeGame();
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

}
