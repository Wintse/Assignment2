using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
public class PlayerController : MonoBehaviour
{
    public PlayerState playerState;

    [Header("object properties")]
    public Animator girl;
    public SpriteRenderer girlSprite;
    public Rigidbody2D rbody;

    [Header("physics")]
    public float move;
    public float jump;

    [Header("laser settings")]
    public GameObject laser;
    public GameObject laserspawn;
    public float fireRate = 0.5f;

    public bool isGrounded;
    public Transform groundTarget;

    public Boundary boundary;
    public float myTime = 0.0f;
    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    { 
       // girl = GetComponent<Animator>();
        isGrounded = false;
        playerState = PlayerState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        //   Movement();
        CheckBoundary();

        isGrounded = Physics2D.BoxCast(
        transform.position, new Vector2(2.0f, 1.0f), 0.0f, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Ground"));

        myTime += Time.deltaTime;
        //idle
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (Input.GetButton("Fire1") && myTime > fireRate)
            {
                playerState = PlayerState.SHOOT;
                girl.SetInteger("state", (int)PlayerState.SHOOT);
                Instantiate(laser, laserspawn.transform.position, laserspawn.transform.rotation);
                myTime = 0.0f;
            }
            else
            {
                playerState = PlayerState.IDLE;
                girl.SetInteger("state", (int)PlayerState.IDLE);
            }


        }

        //right
        if ((Input.GetAxis("Horizontal") > 0) && (isGrounded))
        {
            if (Input.GetButton("Fire1") && myTime > fireRate)
            {
                girlSprite.flipX = false;
                playerState = PlayerState.RUNSHOOT;
                girl.SetInteger("state", (int)PlayerState.RUNSHOOT);
                rbody.AddForce(Vector2.right * move);
                Instantiate(laser, laserspawn.transform.position, laserspawn.transform.rotation);
                myTime = 0.0f;
            }
            else
            {
                girlSprite.flipX = false;
                playerState = PlayerState.RUN;
                girl.SetInteger("state", (int)PlayerState.RUN);
                rbody.AddForce(Vector2.right * move);
            }

        }

        //left
        if ((Input.GetAxis("Horizontal") < 0) && (isGrounded))
        {
            if (Input.GetButton("Fire1") && myTime > fireRate)
            {
                girlSprite.flipX = true;
                playerState = PlayerState.RUNSHOOT;
                girl.SetInteger("state", (int)PlayerState.RUNSHOOT);
                rbody.AddForce(Vector2.left * move);
                Instantiate(laser, laserspawn.transform.position, laserspawn.transform.rotation);
                myTime = 0.0f;
            }
            else
            {
                girlSprite.flipX = true;
                playerState = PlayerState.RUN;
                girl.SetInteger("state", (int)PlayerState.RUN);
                rbody.AddForce(Vector2.left * move);
            }

        }

        //jump
        if ((Input.GetAxis("Jump") > 0) && (isGrounded))
        {
            playerState = PlayerState.JUMP;
            girl.SetInteger("state", (int)PlayerState.JUMP);
            rbody.AddForce(Vector2.up * jump);
            isGrounded = false;
            jumpSound.Play();
        }

    }

    public void CheckBoundary()
    {
        rbody.position = new Vector2(
            Mathf.Clamp(rbody.position.x, boundary.Left, boundary.Right),
            Mathf.Clamp(rbody.position.y, boundary.Bottom, boundary.Top));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //switch(other.gameObject.tag)
        //{
        //    case "Chest":
        //        Destroy(other.gameObject);
        //        break;
        //    case "Enemy":
        //        break;
        //}

        if(other.tag == "Chest")
        {
            Destroy(other.gameObject);
        }
    }

}
