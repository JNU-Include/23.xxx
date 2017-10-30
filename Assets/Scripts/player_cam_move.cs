using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_cam_move : MonoBehaviour {
    GameObject player;

    float[] camInfo = new float[4];
    //[0]xPosi,[1]zPosi, [2]xRota ,[3]zRota    

    float[] CamInfoSet(float[] camInfo)
    {
        
        camInfo[0] = player.transform.position.x;
        camInfo[1] = player.transform.position.z - 7;
        camInfo[2] = player.transform.localEulerAngles.x + 45;
        camInfo[3] = player.transform.localEulerAngles.y;

        float[] something = new float[camInfo.Length];

        for (int i = 0; i < 4; i++)
        {
            something[i] = camInfo[i];
        }

        return something;
    }


    float[] CamInfoRevise(float[] camInfo)
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //camInfo[0] = player.transform.position.x;
            camInfo[0] = 0;
            camInfo[1] = -7;
            camInfo[2] = player.transform.localEulerAngles.x + 45;
            camInfo[3] = player.transform.localEulerAngles.y;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camInfo[0] = 7;
            camInfo[1] = 0;
            camInfo[2] = player.transform.localEulerAngles.x + 45;
            camInfo[3] = player.transform.localEulerAngles.y - 90;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camInfo[0] = 0;
            camInfo[1] = 7;
            camInfo[2] = player.transform.localEulerAngles.x + 45;
            camInfo[3] = player.transform.localEulerAngles.y - 180;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            camInfo[0] = -7;
            camInfo[1] = 0;
            camInfo[2] = player.transform.localEulerAngles.x + 45;
            camInfo[3] = player.transform.localEulerAngles.y - 270;
        }
        else
        {

        }

        float[] something = new float[camInfo.Length];

        for (int i = 0; i < 4; i++)
        {
            something[i] = camInfo[i];
        }

        return something;

    }


    // Use this for initialization
    void Start () {
        player = GameObject.Find("test_player");
        camInfo = this.CamInfoSet(camInfo);

    }
	
	// Update is called once per frame
	void Update () {

        camInfo = this.CamInfoRevise(camInfo);
        transform.position = new Vector3(player.transform.position.x + camInfo[0] , 8, player.transform.position.z + camInfo[1]);
        transform.localEulerAngles = new Vector3(camInfo[2], camInfo[3], 0);
   
    }


}
