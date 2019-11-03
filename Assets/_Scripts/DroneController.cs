using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public SpriteRenderer droneSprite;
    public bool isGrounded;
    public bool hasGroundAhead;
    public Rigidbody2D rbody;
    public Transform lookAhead;
    public bool isFacingRight = false;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        isGrounded = Physics2D.BoxCast(
            transform.position, new Vector2(2.0f, 1.0f), 0.0f, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Ground"));

        hasGroundAhead = Physics2D.Linecast(
            transform.position,
            lookAhead.position,
            1 << LayerMask.NameToLayer("Ground"));


        if (isGrounded)
        {
            if (isFacingRight)
            {
                transform.localScale = new Vector3(-5.0f, 5.0f, 5.0f);
                rbody.velocity = new Vector2(movementSpeed, 0.0f);
            }

            if (!isFacingRight)
            {
                transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                rbody.velocity = new Vector2(-movementSpeed, 0.0f);
            }

            if (!hasGroundAhead)
            {
                transform.localScale = new Vector3(-transform.localScale.x, 5.0f, 5.0f);
                isFacingRight = !isFacingRight;
            }
        }


    }


}
