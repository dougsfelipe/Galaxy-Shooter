using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField] private GameObject enemyShipPrefab;
    [SerializeField] private GameObject[] powerUps;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(enemySpawn());
        StartCoroutine(PoweupSpawnRoutine());
        
    }

    public void StartSpawnRoutine(){
        StartCoroutine(PoweupSpawnRoutine());
        StartCoroutine(enemySpawn());
    }

    // Criar rotina para criar inimigo a cada 5s
    public IEnumerator enemySpawn(){
        while(_gameManager.gameOver==false){
            
            Instantiate(enemyShipPrefab,new Vector3(Random.Range(-8.8f, 8.0f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0F);
        }
        
    }

    public IEnumerator PoweupSpawnRoutine(){
        while(_gameManager.gameOver==false){
            int randonPowerup = Random.Range(0,3);
            Instantiate(powerUps[randonPowerup],new Vector3(Random.Range(-8.8f, 8.0f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0F);
        }
        
    }

}
