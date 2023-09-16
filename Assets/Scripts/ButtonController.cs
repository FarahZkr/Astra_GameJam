using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    bool nearPlayer = false;
    Vector3 startPos;

    public GameObject wall;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = wall.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float platformY = wall.transform.position.y;

        if (Input.GetKey(KeyCode.E) && nearPlayer)
        {
            Debug.Log(startPos.y + 20 + " current position: " + wall.transform.position.y);

            if (platformY >= startPos.y - 2)
            {
                Debug.Log("HIT LIM");
                wall.transform.Translate(Vector2.down * Time.deltaTime * 5);
            }
        }
        else
        {

            if ((platformY <= startPos.y))
            {
                wall.transform.Translate(Vector2.up * Time.deltaTime * 2);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            Debug.Log("entered lim");
        }
        nearPlayer = true;
        Debug.Log("entered LEVER");

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            Debug.Log("ext limit");
        }
        nearPlayer = false;
        Debug.Log("EXIT LEVER");

    }


}