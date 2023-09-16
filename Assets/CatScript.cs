using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public bool isGrounded;
    public float jumpForce = 20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    float velocity;
    bool canJump = true;
    float walkSpeed = 10;

    void Update()
    {
        velocity += gravity * gravityScale * Time.deltaTime;

        // Check if the player is grounded
        if (isGrounded && velocity < 0)
        {
            velocity = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            velocity = jumpForce;
        }

        //Player left and right
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * walkSpeed);
        }


        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3)
        {
            isGrounded = true;
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
            Debug.Log("WHATS GOING ON");
        }
    }

}
