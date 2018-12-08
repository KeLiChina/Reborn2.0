using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : RoleMovment {

    bool autoMove = false;
    Vector3 targetPos;
void Start()
{
 JumpFroce = 1000;
}
void FixedUpdate ()
	{
		// Move our character
	    controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
        
        //开始自动行走
        if (autoMove == true)
        {
            controller.Move(runSpeed * Time.fixedDeltaTime, crouch, jump);
            if ((transform.position - targetPos).magnitude <= 0.5f)
            {
                autoMove = false;
            }
        }
	}


    public void moveTo(Vector3 pos)
    {
        autoMove = true;
        targetPos = pos;
    }
}
