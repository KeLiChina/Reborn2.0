using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : RoleMovment {

	void Update () {

		//horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		// OnMove(m_Horizontal);
		// OnJump(m_Jump);
		// OnHurt(m_Hurt);
		//OnCrouching(m_Crouch);
/* 
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
	

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
*/
	}
void FixedUpdate ()
	{
		// Move our character
        Debug.Log("horizontalMove+++++++++++"+horizontalMove);
	    controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
