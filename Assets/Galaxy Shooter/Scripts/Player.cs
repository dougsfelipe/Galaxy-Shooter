using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Variables
    [SerializeField] private  GameObject _laserPrefabs;
    [SerializeField] private float _speed = 5.0f;
    // Start is called before the first frame update
    [SerializeField]  private float _fireRate = 0.25f;
    public float canFire = 0.0f;

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

        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * VerticalInput);


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
            if(Time.time > canFire){
            Instantiate(_laserPrefabs, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            canFire = Time.time + _fireRate;
            }

        }
    }



}
