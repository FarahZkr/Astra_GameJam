using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour
{
    public bool isGateOpen = false;
    [SerializeField] private AudioSource gateSound;
    [SerializeField] private AudioSource gateClose;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == 7 || collision.gameObject.layer == 8) && !isGateOpen)
        {
            if (isGateOpen == false)
            {
                gateSound.Play();
            }
            isGateOpen = true;
            transform.Translate(Vector2.down * 0.2f);

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == 7 || collision.gameObject.layer == 8) && isGateOpen)
        {
            isGateOpen = false;
            transform.Translate(Vector2.up * 0.2f);
            
            if (isGateOpen == true)
            {
                gateClose.Play();
                
            }
        }
    }
}
