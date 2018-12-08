using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour {

	private Transform  m_TF;
	private bool isDown = true;
	void Awake () {
		m_TF = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
