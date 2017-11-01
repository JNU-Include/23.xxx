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

        
        transform.Rotate(0, Speed * Time.deltaTime, 0);

        /*if (0 <= transform.eulerAngles.y && transform.eulerAngles.y < 18)         
            transform.Rotate(0, Speed * Time.deltaTime, 0);
        
        else if (321 < transform.eulerAngles.y && transform.eulerAngles.y <= 365)  
            transform.Rotate(0, Speed * Time.deltaTime, 0);
        
        else       
            Speed *= -1;*/
            
        

        /*if (17 < transform.eulerAngles.y && transform.eulerAngles.y < 18)        
            Speed *= -1;
        
        else if (320 > transform.eulerAngles.y && transform.eulerAngles.y > 319)                    
            Speed *= -1; */     
    }
}
