﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

/*
 * Victoria Liu
 * laser controller
 * moves the bullet when player shoots
 */

public class LaserController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
         Destroy(this.gameObject,5);
    }
}