using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    //Variavel para velocidade
    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private GameObject _enemyExplosionPrefab;

    [SerializeField] private AudioClip _clip;

    private UIManager _uiManager;

    private AudioSource _audioSource;


    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //mover para baixo

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //repspaw para cima com no posicao x em cima

        if (transform.position.y < -8.0f)
        {
            this.transform.position = new Vector3(Random.Range(-8.8f, 8.0f), 7f, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Laser laser = other.GetComponent<Laser>();
        Player player = other.GetComponent<Player>();
        UIManager ui = other.GetComponent<UIManager>();

        if (other.tag == "Laser")
        {
            if (laser != null)
            {
               
                _uiManager.UpdateScore();
                AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
                Destroy(other.gameObject);
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);


            }
        }

        if (other.tag == "Player")
        {
            if (player != null)
            {
                _uiManager.UpdateScore();
                AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
                Destroy(this.gameObject);
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);

            }

        }

    }


}
