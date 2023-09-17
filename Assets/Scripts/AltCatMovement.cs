using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AltCatMovement : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float moveSpeed;
    public bool isGrounded;
    public float jumpForce;
    NavMeshAgent _agent;
    Animator _animator;
    SpriteRenderer _spriteRenderer;

    void Start()
    {

        m_Rigidbody = GetComponent<Rigidbody2D>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Apply a force to the RigidBody to make the player move
        if (Input.GetButton("Horizontal2"))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _spriteRenderer.flipX = false;
                _animator.SetInteger("side", 2);
            }
            else
            {
                _animator.SetInteger("side", 1);
                _spriteRenderer.flipX = true;
            }
            m_Rigidbody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal2"), m_Rigidbody.velocity.y);
        }
        else
        {
            _animator.SetInteger("side", 0);
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
        Vector2 v = transform.position;
        if (col.gameObject.layer == 3)
        {
            isGrounded = true;
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
        if (col.gameObject.layer == 6)
        {

        }
        if (col.gameObject.tag == "Mushroom")
        {
            Vector2 up = new Vector2(0, jumpForce * 2);
            m_Rigidbody.AddForce(up, ForceMode2D.Impulse);
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