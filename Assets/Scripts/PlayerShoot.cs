using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject launcher;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("k"))
        {
            launcher.SetActive(true);
            gameObject.GetComponent<InputCtrl>().enabled = false;

        }
        else
            if (Input.GetKeyUp("k"))
        {
            //launcher.SetActive(false);
            gameObject.GetComponent<InputCtrl>().enabled = true;
            launcher.GetComponent<Launcher2D>().launch = true;
        }
		
	}
}
