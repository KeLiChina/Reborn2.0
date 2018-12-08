using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCtrl : MonoBehaviour {

	private RoleMovment m_RoleMovment;

	void Awake () {
		m_RoleMovment = gameObject.GetComponent<RoleMovment>();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		m_RoleMovment.OnJump(Input.GetButtonDown("Jump"));
		m_RoleMovment.OnMove( Input.GetAxisRaw("Horizontal"));
	}
}
