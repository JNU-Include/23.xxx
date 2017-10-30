using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMove1 : MonoBehaviour {

    public float Speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(transform.eulerAngles.y);

        transform.Rotate(0, Speed * Time.deltaTime, 0);

        if (255.0f < transform.eulerAngles.y || 183 > transform.eulerAngles.y)
            Speed *= -1;
        

        /*if (183 < transform.eulerAngles.y && transform.eulerAngles.y < 255)
            transform.Rotate(0, Speed * Time.deltaTime, 0);

        else if (transform.eulerAngles.y < 183 || transform.eulerAngles.y > 255)
            transform.Rotate(0, -Speed * Time.deltaTime, 0);*/



    }
}
