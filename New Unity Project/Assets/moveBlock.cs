﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlock : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X)) 
        {
            if (Input.GetKey(KeyCode.LeftShift)) 
            {
                rb.velocity = rb.velocity + new Vector3(0, 0, -0.05f);
            }
            else { rb.velocity = rb.velocity + new Vector3(0, 0, 0.05f); }
            
        }
        
    }
}