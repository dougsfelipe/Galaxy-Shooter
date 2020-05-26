using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isCoop = false;
    public bool gameOver = true;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject playersPrefab;
    private UIManager _uiManager;
    private Spawn_Manager _spawnManager;
    [SerializeField] private GameObject _pauseMenu;

    private Animator _pauseAnimator;
    

    private void Start() {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        _pauseAnimator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();
        _pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(gameOver == true){
            if(Input.GetKeyDown(KeyCode.Space)){

                if(isCoop == false){
                    Instantiate(playerPrefab,new Vector3(0,0,0),Quaternion.identity);
                }else if(isCoop == true){
                    Instantiate(playersPrefab,new Vector3(0,0,0),Quaternion.identity);
                }
                
                gameOver = false;
                _uiManager.HideTitleScreen();
                _spawnManager.StartSpawnRoutine();

            }else if(Input.GetKeyDown(KeyCode.Escape)){
                SceneManager.LoadScene("MainMenu");
            }
        }

        if(Input.GetKeyDown(KeyCode.P)){
            
            _pauseMenu.SetActive(true);
            _pauseAnimator.SetBool("isPause",true);
            Time.timeScale = 0;
            
        }


        
    }

    public void ResumeGame(){

        _pauseMenu.SetActive(false);
        Time.timeScale =1;
    }



   
}
