﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public bool gameOver = true;
    [SerializeField] private GameObject playerPrefab;
    private UIManager _uiManager;

    private void Start() {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(gameOver == true){
            if(Input.GetKeyDown(KeyCode.Space)){
                Instantiate(playerPrefab,new Vector3(0,0,0),Quaternion.identity);
                gameOver = false;
                _uiManager.HideTitleScreen();
            }
        }
        
    }

   
}
