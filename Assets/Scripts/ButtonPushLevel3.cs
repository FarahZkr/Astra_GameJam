using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushLevel3 : MonoBehaviour
{
    bool nearPlayer = false;
    Vector3 startPos;
    public GameObject stairs;
    // Start is called before the first frame update
    void Start()
    {
        stairs.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (nearPlayer)
        {
            stairs.SetActive(true);
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        nearPlayer = true;
        transform.Translate(new Vector2(0.00f, -0.05f));
    }
}
