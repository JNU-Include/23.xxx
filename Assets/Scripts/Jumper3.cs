using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper3 : MonoBehaviour {
    public float Power;
    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        Vector3 Power = new Vector3(0, 300 * Time.deltaTime, 0);
        Power = Power.normalized * 300;

        collision.gameObject.GetComponent<Rigidbody>().AddForce(Power);

    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
