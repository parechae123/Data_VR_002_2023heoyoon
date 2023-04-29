using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerAnimTree
{
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        plrStates = PlrStates.Idle;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) stateUpdate(PlrStates.Idle);
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            if (atkCount>0)
            {
                atkCount++;
            }
            else
            {
                stateUpdate(PlrStates.Attack);
            }
        } 
        if (Input.GetKeyDown(KeyCode.D)) stateUpdate(PlrStates.Run);
        if (Input.GetKeyDown(KeyCode.F)) stateUpdate(PlrStates.Garding);
    }
}
