using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject launcher;
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update() {
        if (gameObject.GetComponent<CharacterController2D>().m_FacingRight)
        {

            if (Input.GetKeyDown("k"))
            {
                launcher.SetActive(true);
                //launcher.GetComponent<Launcher2D>().tp.predictionPoints.Clear();  
                gameObject.GetComponent<InputCtrl>().enabled = false;

            }
            else
                if (Input.GetKeyUp("k"))
            {
                launcher.GetComponent<Launcher2D>().launch = true;

                gameObject.GetComponent<InputCtrl>().enabled = true;

            }
        }
		
	}
    void LateUpdate()
    {
        if (Input.GetKeyUp("k"))
        {
            //launcher.GetComponent<Launcher2D>().tp.predictionPoints.Clear();
            launcher.SetActive(false);
        }
        
    }
}
