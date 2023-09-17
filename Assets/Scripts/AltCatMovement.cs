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
    bool isRight;
    bool canJump;

    void Start()
    {
        isRight = false;
        canJump = true;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Apply a force to the RigidBody to make the player move
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && canJump)
        {
            if (isRight)
            {
                _spriteRenderer.flipX = true;
                _animator.SetInteger("jump", 1);
            }
            else
            {
                _spriteRenderer.flipX = false;
                _animator.SetInteger("jump", 2);
            }

            Vector2 up = new Vector2(0, jumpForce);
            m_Rigidbody.AddForce(up, ForceMode2D.Impulse);
        }
        else if (Input.GetButton("Horizontal2"))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                isRight = false;
                _spriteRenderer.flipX = false;
                if (isGrounded) _animator.SetInteger("side", 2);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                isRight = true;
                if (isGrounded) _animator.SetInteger("side", 1);
                _spriteRenderer.flipX = true;
            }
            m_Rigidbody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal2"), m_Rigidbody.velocity.y);
        }
        else if(!(Input.GetButton("Horizontal2")) || !(Input.GetKeyDown(KeyCode.UpArrow)))
        {
            _animator.SetInteger("side", 0);
        }
        

        // Slow Down the player
        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x * 0.5f, m_Rigidbody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
         if(col.gameObject.layer == 7)
        {
            _animator.SetInteger("jump", 0);
            canJump = false;
        }

        if (col.gameObject.layer == 3)
        {
            isGrounded = true;
            _animator.SetInteger("jump", 0);
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            canJump = true;
        }
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
            if (isRight)
            {
                _spriteRenderer.flipX = true;
                _animator.SetInteger("jump", 1);
            }
            else
            {
                _spriteRenderer.flipX = false;
                _animator.SetInteger("jump", 2);
            }
        }
  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mushroom")
        {
            Vector2 up = new Vector2(0, jumpForce * 2);
            m_Rigidbody.AddForce(up, ForceMode2D.Impulse);
        }
    }
    
}