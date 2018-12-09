using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldTree : MonoBehaviour {

	public Transform shootPos;
	public GameObject Bullrt;
	private Animator m_Animator;
	private bool canShoot = true;
	void Start () {
		m_Animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Shoot()
	{
		if (!canShoot) return;
		canShoot = false;
		var bull = Instantiate(Bullrt,shootPos.position,shootPos.rotation);
		var r2d = bull.GetComponent<Rigidbody2D>();
		r2d.AddForce(new Vector2(-1800f,200f ));
		m_Animator.Play("TarpTrees");
	}
}
