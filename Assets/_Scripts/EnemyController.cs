using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
public class EnemyController : MonoBehaviour
{

    public Boundary boundary;
    public GameObject player;

    [Header("shoot settings")]
    public GameObject bullet;
    public GameObject bulletspawn;
    public float fireRate = 0.5f;

    [Header("explosion settings")]
    public GameObject explosion;

    public GameController gameController;

    public float myTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
          


    }




}
