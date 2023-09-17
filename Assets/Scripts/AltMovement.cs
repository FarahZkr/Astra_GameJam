using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AltMovement : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float moveSpeed;
    public bool isGrounded;
    public float jumpForce;
    NavMeshAgent _agent;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    bool isRight;

    void Start()
    {
        isRight = false;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isRight)
            Debug.Log("Right");
        else
            Debug.Log("Left");
        //Apply a force to the RigidBody to make the player move
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (isRight)
            {
                _spriteRenderer.flipX = false;
                _animator.SetInteger("side", 3);
                Debug.Log("rihgt");
            }
            else
            {
            //_spriteRenderer.flipX = true;
            _animator.SetInteger("side", 3);
            }
            Vector2 up = new Vector2(0, jumpForce);
            m_Rigidbody.AddForce(up, ForceMode2D.Impulse);
        }
        else
        {
            _animator.SetInteger("side", 0);
        }
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetKey(KeyCode.A))
            {
                isRight = false;
                _spriteRenderer.flipX = true;
                _animator.SetInteger("side", 2);
            }
            else
            {
                isRight = true;
                _animator.SetInteger("side",1);
                _spriteRenderer.flipX = false;
            }
            m_Rigidbody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), m_Rigidbody.velocity.y);
        }
        else
        {
            _animator.SetInteger("side", 0);
        }


        // Slow Down the player

        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x * 0.5f, m_Rigidbody.velocity.y);

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3)
        {
            isGrounded = true;
            //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }

    }
     void OnTriggerStay2D(Collider2D col)
       {
        if (col.gameObject.layer == 3)
        {
            isGrounded = true;
            //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Mushroom")
        {
            Vector2 up = new Vector2(0, jumpForce * 2);
            m_Rigidbody.AddForce(up, ForceMode2D.Impulse);
        }
    }
}