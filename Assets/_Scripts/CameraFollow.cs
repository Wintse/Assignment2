using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Util;
public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public Boundary boundary;


    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckBoundary();
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.Left, boundary.Right),
            Mathf.Clamp(transform.position.y, boundary.Bottom, boundary.Top),
            transform.position.z);
    }

  

}
