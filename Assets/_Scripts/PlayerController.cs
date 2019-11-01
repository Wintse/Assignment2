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

    public Boundary boundary;

    public bool grounded;
    public Transform groundTarget;

    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    { 
       // girl = GetComponent<Animator>();
        grounded = false;
        playerState = PlayerState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        grounded = Physics2D.BoxCast(
            transform.position, new Vector2(2.0f, 1.0f), 0.0f, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Ground"));

        //idle
        if (Input.GetAxis("Horizontal") == 0)
        {
            playerState = PlayerState.IDLE;
            girl.SetInteger("state", (int)PlayerState.IDLE);
        }

        //right
        if((Input.GetAxis("Horizontal") > 0) && (grounded))
        {
            girlSprite.flipX = false;
            playerState = PlayerState.RUN;
            girl.SetInteger("state", (int)PlayerState.RUN);
            rbody.AddForce(Vector2.right * move);
        }

        //left
        if((Input.GetAxis("Horizontal") < 0) && (grounded))
        {         
            girlSprite.flipX = true;
            playerState = PlayerState.RUN;
            girl.SetInteger("state", (int)PlayerState.RUN);
            rbody.AddForce(Vector2.left * move);         
        }

        //jump
        if((Input.GetAxis("Jump") > 0) && (grounded))
        {
            playerState = PlayerState.JUMP;
            girl.SetInteger("state", (int)PlayerState.JUMP);
            rbody.AddForce(Vector2.up * jump);
            grounded = false;
            jumpSound.Play();
        }

        CheckBoundary();
    }

    public void CheckBoundary()
    {
        rbody.position = new Vector2(
            Mathf.Clamp(rbody.position.x, boundary.Left, boundary.Right),
            Mathf.Clamp(rbody.position.y, boundary.Bottom, boundary.Top));
    }


}
