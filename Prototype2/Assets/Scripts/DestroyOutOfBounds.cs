﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float upperBound = 40f;
    private float lowerBound = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > upperBound) {
            Destroy(gameObject);
        } else if(transform.position.z < lowerBound) {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
