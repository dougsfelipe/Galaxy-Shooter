using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private int powerUpID;  
    [SerializeField] private AudioClip _clip;
    
    
    
    
    
  // 0= tripleshot, 1= speed bost, 2 = shield

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collid with : " + other.name);


        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            if(player != null){

                if(powerUpID == 0){    
                player.TripleShotPowerdownOn();
                }else if(powerUpID == 1){
                    player.SpeedBostdownOn();
                }else if(powerUpID == 2){
                    player.ShielddownOn();
                }


            }

            
            Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if(transform.position.y < -7){
            Destroy(this.gameObject);
        }

    }
}
