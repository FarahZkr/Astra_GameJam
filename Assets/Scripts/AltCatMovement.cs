using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCatMovement : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float moveSpeed;
    public bool isGrounded;
    public float jumpForce;

    void Start()
    {

        m_Rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //Apply a force to the RigidBody to make the player move
        if (Input.GetButton("Horizontal2"))
        {
            m_Rigidbody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal2"), m_Rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Vector2 up = new Vector2(0, jumpForce);
            m_Rigidbody.AddForce(up, ForceMode2D.Impulse);
        }


        // Slow Down the player

        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x * 0.5f, m_Rigidbody.velocity.y);



    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 3)
        {
            isGrounded = true;
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
        if (col.gameObject.layer == 6)
        {

        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
            Debug.Log("WHATS GOING ON");
        }

    }
}