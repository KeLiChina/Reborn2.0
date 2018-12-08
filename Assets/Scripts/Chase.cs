using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public Transform playerTrans;


    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log(playerTrans.gameObject.name);
    }

    void FixedUpdate()
    {
             
        this.transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, playerTrans.position.z);
        
    }

}
