using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSript : MonoBehaviour
{
    public string isDoorOpenParamName = "isDoorOpen";

    Animator animator;
    public GateButton button;
    public GateButton button1;
    PolygonCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isOpen = button.isGateOpen || button1.isGateOpen;
        animator.SetBool(isDoorOpenParamName, isOpen);
        boxCollider.enabled = !isOpen;
    }
}
