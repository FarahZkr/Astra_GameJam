using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    bool nearPlayer = false;
    bool toStop;
    float distance = 0;
    Vector3 startPos;

    public GameObject wall;
        // Start is called before the first frame update
    void Start()
    {
         startPos = wall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E) && nearPlayer)
        {
            if (!(wall.transform.position == startPos))
            {
                wall.transform.Translate(Vector2.down * Time.deltaTime * 5);
                distance += 10;
            }
        }
        else
        {
            if (!toStop)
            {
                wall.transform.Translate(Vector2.up * Time.deltaTime * 2);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            toStop = true;
            Debug.Log("entered lim");
        }
        nearPlayer = true;
        Debug.Log("entered LEVER");

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            toStop = false;
            Debug.Log("ext limit");
        }
        nearPlayer = false;
        Debug.Log("EXIT LEVER");

    }


}