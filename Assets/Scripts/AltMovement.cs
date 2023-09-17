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
    bool canJump;

    void Start()
    {
        canJump = true;
        isRight = false;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
     
        //Apply a force to the RigidBody to make the player move
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            if (isRight)
            {
                _spriteRenderer.flipX = false;
                _animator.SetInteger("jump", 1);
            }
            else
            {
                _spriteRenderer.flipX = true;
                _animator.SetInteger("jump", 2);
            }
            Vector2 up = new Vector2(0, jumpForce);
            m_Rigidbody.AddForce(up, ForceMode2D.Impulse);
        }
        else if (Input.GetButton("Horizontal"))
        {
            if (Input.GetKey(KeyCode.A))
            {
                isRight = false;
                _spriteRenderer.flipX = true;
                if (isGrounded) _animator.SetInteger("side", 2);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                isRight = true;
                if (isGrounded) _animator.SetInteger("side", 1);
                _spriteRenderer.flipX = false;
            }
            m_Rigidbody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), m_Rigidbody.velocity.y);
        }
        else if (!(Input.GetButton("Horizontal")) || !(Input.GetKeyDown(KeyCode.Space)))
        {
            _animator.SetInteger("side", 0);
        }


        // Slow Down the player
        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x * 0.5f, m_Rigidbody.velocity.y);

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
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
        if (collision.gameObject.layer == 8)
        {
            canJump = true;
        }
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
            if (isRight)
            {
                _spriteRenderer.flipX = false;
                _animator.SetInteger("jump", 1);
            }
            else
            {
                _spriteRenderer.flipX = true;
                _animator.SetInteger("jump", 2);
            }
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

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }
    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 3)
    //    {
    //        //isGrounded = false;
    //        //if (isRight)
    //        //{
    //        //    _spriteRenderer.flipX = false;
    //        //    _animator.SetInteger("jump", 1);
    //        //}
    //        //else
    //        //{
    //        //    _spriteRenderer.flipX = true;
    //        //    _animator.SetInteger("jump", 2);
    //        //}
    //        Debug.Log("WHATS GOING ON");
    //    }

    //}
}