﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PlayerState playerState;

    [Header("object properties")]
    public Animator girl;
    public SpriteRenderer girlSprite;
    public Rigidbody2D rbodyPlayer;
    

    [Header("physics")]
    public float move;
    public float jump;
    public bool isGrounded;
    public Transform groundTarget;
    public Vector2 maximumVelocity = new Vector2(20.0f, 30.0f);

    [Header("taser settings")]
    public GameObject taserObject;

    public Boundary boundary;
    public float myTime = 0.0f;
    public GameController gameController;
    public bool facingDirection;



    [Header("Sounds")]
    private AudioSource _jumpSound;
    private AudioSource _taserSound;
    private AudioSource _chestSound;
    private AudioSource _hurtSound;
    private AudioSource _fallSound;

    


    // Start is called before the first frame update
    void Start()
    { 
       // girl = GetComponent<Animator>();
        isGrounded = false;
        playerState = PlayerState.IDLE;

        _jumpSound = gameController.audioSource[(int)Sound.JUMPING];
        _taserSound = gameController.audioSource[(int)Sound.TASE];
        _chestSound = gameController.audioSource[(int)Sound.TREASURE];
        _hurtSound = gameController.audioSource[(int)Sound.HURT];
        _fallSound = gameController.audioSource[(int)Sound.FALL];

        facingDirection = true;

        //finding the Game Controller by the tag GameController
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            //get the gamecontroller so it can be used
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        //if gamecontroller can't be found
        if (gameController == null)
        {
            //tell me its not there
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckBoundary();

    }

    void Movement()
    {
       // Collider2D taser = gameObject.GetComponent<CircleCollider2D>();
        //taser.isTrigger = false;

        isGrounded = Physics2D.BoxCast(
        transform.position, new Vector2(2.0f, 1.0f), 0.0f, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Ground"));


        myTime += Time.deltaTime;
        //idle
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (Input.GetButton("Fire1"))
            {
                playerState = PlayerState.SHOOT;
                girl.SetInteger("state", (int)PlayerState.SHOOT);


                taserObject.gameObject.GetComponent<CircleCollider2D>().isTrigger = true ;
            

                _taserSound.Play();
            }
            else
            {
                playerState = PlayerState.IDLE;
                girl.SetInteger("state", (int)PlayerState.IDLE);


                taserObject.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
           

            }


        }

        //right
        if (Input.GetAxis("Horizontal") > 0)
        {
            if(isGrounded)
            {
                facingDirection = true;
                transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
                if (Input.GetButton("Fire1") )
                {             
                    playerState = PlayerState.RUNSHOOT;
                    girl.SetInteger("state", (int)PlayerState.RUNSHOOT);
                    rbodyPlayer.AddForce(Vector2.right * move);
                    //rbodyPlayer.AddForce(new Vector2(1, 1) * move);

                    taserObject.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
                   

                    _taserSound.Play();
                    myTime = 0.0f;
                }
                else
                {               
                    playerState = PlayerState.RUN;
                    girl.SetInteger("state", (int)PlayerState.RUN);
                    rbodyPlayer.AddForce(Vector2.right * move);
                    //rbodyPlayer.AddForce(new Vector2(1, 1) * move);

                    taserObject.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                //   taser.isTrigger = false;

                }
            }
            

        }

        //left
        if (Input.GetAxis("Horizontal") < 0)
        {
            if(isGrounded)
            {
                facingDirection = false;
                transform.localScale = new Vector3(-4.0f, 4.0f, 4.0f);
                if (Input.GetButton("Fire1"))
                {
                    playerState = PlayerState.RUNSHOOT;
                    girl.SetInteger("state", (int)PlayerState.RUNSHOOT);
                    rbodyPlayer.AddForce(Vector2.left * move);
                  //  rbodyPlayer.AddForce(new Vector2(-1, 1) * move);

                    taserObject.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
                 //    taser.isTrigger = true;

                    _taserSound.Play();
                    myTime = 0.0f;
                }
                else
                {
                    playerState = PlayerState.RUN;
                    girl.SetInteger("state", (int)PlayerState.RUN);
                    rbodyPlayer.AddForce(Vector2.left * move);
                 //   rbodyPlayer.AddForce(new Vector2(-1, 1) * move);

                    taserObject.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                
                }
            }
            

        }

        //jump
        if (Input.GetAxis("Jump") > 0)
        {
            if(isGrounded)
            {
                playerState = PlayerState.JUMP;
                girl.SetInteger("state", (int)PlayerState.JUMP);
                rbodyPlayer.AddForce(Vector2.up * jump);
                isGrounded = false;
                _jumpSound.Play();

            }
            
        }


        rbodyPlayer.velocity = new Vector2(
            Mathf.Clamp(rbodyPlayer.velocity.x, -maximumVelocity.x, maximumVelocity.x),
            Mathf.Clamp(rbodyPlayer.velocity.y, -maximumVelocity.y, maximumVelocity.y)
        );

       

    }

    /// <summary>
    /// this makes sure the player stays within the borders of the game
    /// </summary>
    public void CheckBoundary()
    {
        rbodyPlayer.position = new Vector2(
            Mathf.Clamp(rbodyPlayer.position.x, boundary.Left, boundary.Right),
            Mathf.Clamp(rbodyPlayer.position.y, boundary.Bottom, boundary.Top));
    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Chest"))
        {
            gameController.collected++;
            _chestSound.Play();
            Destroy(other.gameObject);
        }
        

        if (other.gameObject.CompareTag("Enemy"))
        {
            if(taserObject.gameObject.GetComponent<CircleCollider2D>().isTrigger == false)
            {
                if (gameController.health > 1)
                {
                    _hurtSound.Play();
                    gameController.health--;
                }
                else
                {
                    //if health is = 0, destroy the player
                    gameController.health = 0;
                    
                    
                }
            }
            
        }

        if(other.gameObject.CompareTag("DeathPlane"))
        {
            _fallSound.Play();
            gameController.health--;
        }

        if(other.gameObject.CompareTag("FinishArea"))
        {
            SceneManager.LoadScene("End");
        }


    }


}
