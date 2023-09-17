using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.constraints |= RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        m_Rigidbody.freezeRotation = true;
    }

    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("COLLISION " + collision.gameObject.layer);
        if (collision.gameObject.layer == 7)
        {
            m_Rigidbody.constraints = RigidbodyConstraints2D.None;
            m_Rigidbody.freezeRotation = true;
        }
        else
        {
            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            m_Rigidbody.freezeRotation = true;

        }
    }

}