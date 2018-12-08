using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : RoleMovment {


void FixedUpdate ()
	{
		// Move our character
	    controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
