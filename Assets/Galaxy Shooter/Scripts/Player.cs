using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
  
    [SerializeField] private  GameObject _laserPrefabs;

    [SerializeField] private  GameObject _tripleShotPrefab;

    [SerializeField] private  GameObject _Explosion;
    [SerializeField] private float speed = 5.0f;
    // Start is called before the first frame update
    [SerializeField]  private float _fireRate = 0.25f;

    [SerializeField]  private GameObject _shieldGameObject;

    public int _lifes = 3;
    public float canFire = 0.0f;

    public bool canTripleShot = false;
    public bool canSpeedBost = false;
    public bool shieldOn = false;

    
    private UIManager _uimManager;
    private GameManager _gamemanger;       
    private Spawn_Manager _spawnManager;
    private AudioSource _audioSource;

    [SerializeField] private GameObject[] _engines;

    private int hitCount = 0;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("Game begins");

        _uimManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gamemanger = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();

        if(_spawnManager != null){
            _spawnManager.StartSpawnRoutine();
        }

        if(_uimManager != null){
            _uimManager.UpdateLives(_lifes);
        }

        _audioSource = GetComponent<AudioSource>();

        hitCount = 0;
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
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput * 1.5f);
            transform.Translate(Vector3.up * Time.deltaTime * speed * VerticalInput * 1.5f);
        }else{
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * VerticalInput);
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
                _audioSource.Play();
                Instantiate(_laserPrefabs, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            canFire = Time.time + _fireRate;
            }else if(canTripleShot && Time.time > canFire){
                _audioSource.Play();
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

     public void ShielddownOn(){
        shieldOn =  true;
        _shieldGameObject.SetActive(true);
        StartCoroutine(ShieldPowerdown());
    }
    
     public IEnumerator TripleShotPowerdown(){
        yield return new WaitForSeconds(5.0F);
        canTripleShot = false;
        
    }

    public IEnumerator SpeedBostPowerdown(){
        yield return new WaitForSeconds(8.0F);
        canSpeedBost = false;
        
    }

    public IEnumerator ShieldPowerdown(){
        yield return new WaitForSeconds(8.0F);
        shieldOn = false;
        _shieldGameObject.SetActive(false);
        
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyAI enemy = other.GetComponent<EnemyAI>();


        if(other.tag == "Enemy"){
        if (enemy != null && _lifes > 0 && shieldOn == false)
        {
            hitCount++;
            _lifes--;
            if(_uimManager != null){
            _uimManager.UpdateLives(_lifes);
        }
            

        }else if(_lifes == 0 && shieldOn ==false){

            Instantiate(_Explosion, transform.position , Quaternion.identity);
            _gamemanger.gameOver = true;
            _uimManager.ShowTitleScreen();
            Destroy(this.gameObject);
           


        }else if(shieldOn==true){
            shieldOn=false;
            _shieldGameObject.SetActive(false);
            return;
        }

        if(hitCount == 1){

            _engines[0].SetActive(true);
        }else if(hitCount ==2){
            _engines[1].SetActive(true);
        }

        }

    }

   



}
