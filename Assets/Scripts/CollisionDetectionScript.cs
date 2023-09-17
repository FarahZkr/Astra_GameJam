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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Human")
        {
            m_Rigidbody.constraints = RigidbodyConstraints2D.None;
            m_Rigidbody.freezeRotation = true;
        }
        else
        {
            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            m_Rigidbody.freezeRotation = true;

        }
        //if (collision.name == "Cat")
    }
}