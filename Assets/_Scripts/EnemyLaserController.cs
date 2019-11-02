using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Victoria Liu
 * laser controller
 * moves the bullet when player shoots
 */

public class EnemyLaserController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1);
    }
}
