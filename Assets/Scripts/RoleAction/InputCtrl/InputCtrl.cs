using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCtrl : MonoBehaviour {

	private RoleMovment m_RoleMovment;
	public bool _g = false;
	Rigidbody2D rb2D ;

	void Awake () {
		m_RoleMovment = gameObject.GetComponent<RoleMovment>();
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		m_RoleMovment.OnJump(Input.GetButtonDown("Jump"));
		m_RoleMovment.OnMove( Input.GetAxisRaw("Horizontal"));
		if (GlobalManager.instance.isG)
		{
			rb2D.gravityScale = -3;
			
		}else
			rb2D.gravityScale = 3;
			
		Debug.Log("GlobalManager.instance.isG..."+GlobalManager.instance.isG);
	}
}
