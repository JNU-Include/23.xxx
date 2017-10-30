using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "test_player")
        {
            Application.LoadLevel("ss");
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
