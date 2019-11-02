using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
public class EnemyController : MonoBehaviour
{
    public EnemyState enemyState;
    public Animator turret;
    public SpriteRenderer turretSprite;

    [Header("shoot settings")]
    public GameObject laser;
    public GameObject laserspawn;
    public float fireRate = 0.5f;

    [Header("explosion settings")]
    public GameObject explosion;

    public GameController gameController;
    public GameObject Player;

    public float myTime = 0.0f;
    public float waitTime = 5;
    public float distance = 5;

    // Start is called before the first frame update
    void Start()
    {
        enemyState = EnemyState.SPIN;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Player.transform.position.x <= distance)
        {
            enemyState = EnemyState.SHOOT;
            turret.SetInteger("state", (int)EnemyState.SHOOT);
            myTime += Time.deltaTime;
            if(myTime > waitTime)
            {
                
                Instantiate(laser, laserspawn.transform.position, laserspawn.transform.rotation);
                myTime = 0.0f;
            }
            
        }
        else
        {
            enemyState = EnemyState.SPIN;
        }


    }



}
