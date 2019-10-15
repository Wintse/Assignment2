using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    [Header("object properties")]
    public Animator girl;
    public SpriteRenderer girlSprite;

    private Rigidbody2D rbody;

    [Header("physics")]
    public float move;
    public float jump;

    public bool ground;
    public Transform groundTarget;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        girl = GetComponent<Animator>();
        ground = false;
        girl.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        ground = Physics2D.BoxCast(
            transform.position, new Vector2(2.0f, 1.0f), 0.0f, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Ground"));

        //idle
        if (Input.GetAxis("Horizontal") == 0)
        {
            girl.Play("idle");
           // girl.SetInteger("state", (int)"idle");

        }
        //right
        if(Input.GetAxis("Horizontal") > 0)
        {
            girlSprite.flipX = false;
            girl.Play("run");
            rbody.AddForce(Vector2.right * move);
        }
        //left
        if(Input.GetAxis("Horizontal") < 0)
        {
            girlSprite.flipX = true;
            girl.Play("run");
            rbody.AddForce(Vector2.left * move);
        }
        //jump
        if(Input.GetAxis("Jump") > 0)
        {
            girl.Play("jump");
            rbody.AddForce(Vector2.up * jump);
           // ground = false;
        }

    }
}
