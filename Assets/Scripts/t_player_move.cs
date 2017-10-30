using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_player_move : MonoBehaviour {
    public int Speed;
    public int JumpPower;
    int[] moveArrow = new int[8];
    //[0]xDir1, [1]yDir1, [2]xDir2, [3]yDir2, [4]xDir3, [5]yDir3, [6]xDir4, [7]yDir4 

    int[] MoveArrowSet(int[] moveArrow)
    {
        moveArrow[0] = -1; moveArrow[1] = 0;
        moveArrow[2] = 1; moveArrow[3] = 0;
        moveArrow[4] = 0; moveArrow[5] = 1;
        moveArrow[6] = 0; moveArrow[7] = -1;

        int[] something = new int[moveArrow.Length];

        for (int i = 0; i < 7; i++)
        {
            something[i] = moveArrow[i];
        }

        return something;
    }

    int [] MoveArrowRevise(int[] moveArrow)
    {
        //카메라1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            moveArrow[0] = -1;  moveArrow[1] = 0;
            moveArrow[2] = 1;   moveArrow[3] = 0;
            moveArrow[4] = 0;   moveArrow[5] = 1;
            moveArrow[6] = 0;   moveArrow[7] = -1;
        }
        //카메라2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            moveArrow[0] = 0;   moveArrow[1] = -1;
            moveArrow[2] = 0;   moveArrow[3] = 1;
            moveArrow[4] = -1;  moveArrow[5] = 0;
            moveArrow[6] = 1;   moveArrow[7] = 0;
        }
        //카메라3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            moveArrow[0] = 1;   moveArrow[1] = 0;
            moveArrow[2] = -1;  moveArrow[3] = 0;
            moveArrow[4] = 0;   moveArrow[5] = -1;
            moveArrow[6] = 0;   moveArrow[7] = 1;
        }
        //카메라4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            moveArrow[0] = 0;   moveArrow[1] = 1;
            moveArrow[2] = 0;   moveArrow[3] = -1;
            moveArrow[4] = 1;   moveArrow[5] = 0;
            moveArrow[6] = -1;  moveArrow[7] = 0;
        }
        int[] something = new int[moveArrow.Length];

        for (int i = 0; i < 7; i++)
        {
            something[i] = moveArrow[i];
        }

        return something;
    }

    // Use this for initialization
    void Start () {
        MoveArrowSet(moveArrow);

    }
	
	// Update is called once per frame
	void Update () {
        MoveArrowRevise(moveArrow);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(moveArrow[0], 0, moveArrow[1]) * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(moveArrow[2], 0, moveArrow[3]) * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(moveArrow[4], 0, moveArrow[5]) * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(moveArrow[6], 0, moveArrow[7]) * Speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpPower);
        }
        
    }
}

