﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Effect : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start() {
         Destroy(this.gameObject, 4);
    }
   

}
