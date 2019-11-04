using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    public Transform activeCheckpoint;
    public GameObject player;
    public GameObject checkpoint2;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    ////// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = activeCheckpoint.position;
        }
        //if (player.gameObject.CompareTag("Checkpoint"))
        //{
        //    Debug.Log("Checkpoint 2");
        //    activeCheckpoint.position = checkpoint2.transform.position;
        //}
        
        
    }

}
