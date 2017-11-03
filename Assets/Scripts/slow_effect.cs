using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow_effect : MonoBehaviour {

    //원하는 지형에 넣으면 밟을때 감속효과 생김
    //slowRate 로 감속률 조정
    public bool slow = true;
    GameObject player;
    public float slowRate = 0.3f;
    float originSpeed;
    float loseSpeed;

    
    private void OnCollisionStay(Collision collision)
    {
        t_player_move player_move = GameObject.FindGameObjectWithTag("Player").GetComponent<t_player_move>();
        float originSpeed = player_move.Speed;

        if (slow == true)
        {
            loseSpeed = originSpeed * slowRate;
            originSpeed *= (1 - slowRate);
            Debug.Log(originSpeed);
            player_move.getSpeed(originSpeed);
            slow = false;
        }
        else
        {

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        t_player_move player_move = GameObject.FindGameObjectWithTag("Player").GetComponent<t_player_move>();
        float originSpeed = player_move.Speed;
        originSpeed = originSpeed + loseSpeed;
        player_move.getSpeed(originSpeed);
        slow = true;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

