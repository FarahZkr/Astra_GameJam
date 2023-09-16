using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCatMovement : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float moveSpeed;
    public bool canJump;
    public float jumpForce;

    void Start()
    {

        canJump = false;
        m_Rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //Apply a force to the RigidBody to make the player move
        if (Input.GetButton("Horizontal2"))
        {
            m_Rigidbody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal2"), m_Rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump == true)
        {
            Vector2 up = new Vector2(0, jumpForce);
            m_Rigidbody.AddForce(up, ForceMode2D.Impulse);
            canJump = false;
        }


        // Slow Down the player

        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x * 0.5f, m_Rigidbody.velocity.y);



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Ground")
        {
            canJump = true;
        }

        else
        {
            canJump = false;
        }
    }
}