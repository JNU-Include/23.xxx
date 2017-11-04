using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Camera : MonoBehaviour {

	Transform tr;



	void Awake () {

		tr = GameObject.FindGameObjectWithTag ("Player").transform;
	}



	void LateUpdate () {

		transform.position = tr.position;
	}

}
