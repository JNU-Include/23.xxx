using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {

    GameObject jumper2;

    void OnCollisionEnter(Collision collision)
    {
        Vector3 direction =  jumper2.transform.position - transform.position;
        direction = direction.normalized*1000;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    }
	// Use this for initialization
	void Start () {
        jumper2 = GameObject.Find("jumper2");
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
