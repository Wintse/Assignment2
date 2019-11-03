using System.Collections;
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
    //public PlayerController pscript;
    public GameObject laser;
    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        //if (Input.GetKeyDown(KeyCode.A))
        //{

        //    //Instantiate(laser, laserspawn.position, laserspawn.rotation);
        //    //laser.GetComponent<Rigidbody>().velocity = laser.transform.forward * 6;

        //    //Destroy(laser, 2.0f);

        //}

    }

    // Update is called once per frame
    void Update()
    {

        Destroy(this.gameObject, 2);


    }

}
