using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadSinglePlayerGame(){
        
        SceneManager.LoadScene("Single_Mode");
    }

    public void LoadMultiplayerGame(){
         SceneManager.LoadScene("Coop_Mode");
    }
}
