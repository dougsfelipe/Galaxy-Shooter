﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move up at 10 speed
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y >= 6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyAI enemy = other.GetComponent<EnemyAI>();
        if (other.tag == "Enemy")
        {
            if (enemy != null)
            {

                Destroy(other.gameObject);
                Destroy(this.gameObject);

            }
        }
    }
}
