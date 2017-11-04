using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Jump : MonoBehaviour {
//	private bool jump = false;
	public int jumpPower;
	Rigidbody rigdbody;
	// Use this for initialization
	void Awake(){
		rigdbody = GetComponent<Rigidbody>();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			rigdbody.AddForce (Vector3.up * jumpPower);
		}
	}
}
