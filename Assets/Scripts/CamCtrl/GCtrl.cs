using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCtrl : MonoBehaviour {

	private Rigidbody2D rb2D;
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalManager.instance.isG)
		{
			rb2D.gravityScale = -3;
			
		}else
			rb2D.gravityScale = 3;
	}
}
