using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Variables
    [SerializeField] private  GameObject _laserPrefabs;

    [SerializeField] private  GameObject _tripleShotPrefab;
    [SerializeField] private float _speed = 5.0f;
    // Start is called before the first frame update
    [SerializeField]  private float _fireRate = 0.25f;
    public float canFire = 0.0f;

    public bool canTripleShot = false;
    public bool canSpeedBost = false;


    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("Game begins");
    }

    // Update is called once per frame
    void Update()
    {
        //restrições da tela
        Movement();
        Shoot();

    }

    

    private void Movement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        if(canSpeedBost){
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput * 1.5f);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * VerticalInput * 1.5f);
        }else{
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * VerticalInput);
        }

        

        //Limites do jogador
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.4f)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.4f)
        {
            transform.position = new Vector3(9.4f, transform.position.y, 0);
        }

    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            //spawn laser
            if(Time.time > canFire && !canTripleShot){
                Instantiate(_laserPrefabs, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            canFire = Time.time + _fireRate;
            }else if(canTripleShot && Time.time > canFire){
                Instantiate(_tripleShotPrefab, transform.position - new Vector3(0.75f, 0, 0), Quaternion.identity);
                canFire = Time.time + _fireRate;
            }

        }
    }

    public void TripleShotPowerdownOn(){
        canTripleShot =  true;
        StartCoroutine(TripleShotPowerdown());
    }

    public void SpeedBostdownOn(){
        canSpeedBost =  true;
        StartCoroutine(SpeedBostPowerdown());
    }
     public IEnumerator TripleShotPowerdown(){
        yield return new WaitForSeconds(5.0F);
        canTripleShot = false;
        
    }

    public IEnumerator SpeedBostPowerdown(){
        yield return new WaitForSeconds(8.0F);
        canSpeedBost = false;
        
    }

   



}
