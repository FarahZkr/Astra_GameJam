using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Movement : MonoBehaviour
{
    public bool isGrounded;
    public bool canWalk;
    public float jumpForce = 20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    float velocity;
    bool canJump = true;
    float walkSpeed = 10;
    public Rigidbody2D rb;

    private void Start()
    {
        canWalk = true;
    }

    void Update()
    {
        // velocity += gravity * gravityScale * Time.deltaTime;

        // Check if the player is grounded
        /*if (isGrounded && velocity < 0)
        {
            velocity = 0;
        }*/
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //Player left and right
        if (Input.GetKey(KeyCode.A) && canWalk)
        {
            transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);

        }
        if (Input.GetKey(KeyCode.D) && canWalk)
        {
            transform.Translate(Vector2.right * Time.deltaTime * walkSpeed);
        }


        // transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 v = transform.position;
        if (col.gameObject.layer == 3)
        {
            isGrounded = true;
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
        if(col.gameObject.layer == 6)
        {

            //transform.position = v;
            canWalk = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
            Debug.Log("WHATS GOING ON");
        }
        if (collision.gameObject.layer == 6)
        {
            canWalk = true;
        }
    }

}