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
    public Text bestScore;
    public int score;
    public int bestscoretext = 0;
    public bool start;
    public GameObject titleScreen;


    public void Start() {
        bestscoretext = PlayerPrefs.GetInt("bestscore",0);
        bestScore.text = "Best: " + bestscoretext;
    }
    public void UpdateLives(int currentlives)
    {
        livesImageDisplay.sprite = lives[currentlives];
        Debug.Log(currentlives);
    }

    public void CheckForBestScore(){
        if(score > bestscoretext){
            bestscoretext = score;
            PlayerPrefs.SetInt("bestscore",bestscoretext);
            bestScore.text = "Best: " + bestscoretext;
        }
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
