using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    bool nearPlayer = false;
    Vector3 startPos;

    public GameObject platform;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = platform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float platformY = platform.transform.position.y;

        if (Input.GetKey(KeyCode.E) && nearPlayer)
        {

            if (platformY >= startPos.y - 2)
            {
                Debug.Log("HIT LIM");
                platform.transform.Translate(Vector2.down * Time.deltaTime * 5);
            }
        }
        else
        {
            if ((platformY <= startPos.y))
            {
                platform.transform.Translate(Vector2.up * Time.deltaTime * 2);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 7 || col.gameObject.layer == 8)
        {
            Debug.Log("entered lim");
        }
        nearPlayer = true;
        Debug.Log("entered LEVER");

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 7 || col.gameObject.layer == 8)
        {
            Debug.Log("ext limit");
        }
        nearPlayer = false;
        Debug.Log("EXIT LEVER");

    }


}