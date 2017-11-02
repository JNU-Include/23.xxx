using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow_effect : MonoBehaviour {

    public bool slow = true;
    GameObject player;
    public float slowRate = 0.3f;
    
    private void OnCollisionEnter(Collision collision)
    {
        t_player_move player_move = GameObject.FindGameObjectWithTag("Player").GetComponent<t_player_move>();
        float originSpeed = player_move.Speed;
        Debug.Log(originSpeed);
        Debug.Log("touch");

        if (slow == true)
        {
            originSpeed *= (1-slowRate);
            Debug.Log(originSpeed);
            player_move.getSpeed(originSpeed);
            slow = false;
        }
        else
        {

        }
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
