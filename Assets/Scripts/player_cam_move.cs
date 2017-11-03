using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_cam_move : MonoBehaviour {
    GameObject player;
    GameObject p_cam;
    float[] camInfo = new float[4];
    //[0]xPosi,[1]zPosi, [2]xRota ,[3]zRota    

    float[] CamInfoSet(float[] camInfo)
    {
        
        camInfo[0] = player.transform.position.x -9;
        camInfo[1] = player.transform.position.z;
        camInfo[2] = p_cam.transform.localEulerAngles.x;
        camInfo[3] = p_cam.transform.localEulerAngles.y;

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
            camInfo[0] = -9;
            camInfo[1] = 0;
            camInfo[2] = p_cam.transform.localEulerAngles.x +30;
            camInfo[3] = p_cam.transform.localEulerAngles.y;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camInfo[0] = 0;
            camInfo[1] = 9;
            camInfo[2] = p_cam.transform.localEulerAngles.x + 30;
            camInfo[3] = p_cam.transform.localEulerAngles.y - 90;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camInfo[0] = 9;
            camInfo[1] = 0;
            camInfo[2] = p_cam.transform.localEulerAngles.x + 30;
            camInfo[3] = p_cam.transform.localEulerAngles.y - 180;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            camInfo[0] = 0;
            camInfo[1] = -9;
            camInfo[2] = p_cam.transform.localEulerAngles.x + 30;
            camInfo[3] = p_cam.transform.localEulerAngles.y - 270;
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
        p_cam = GameObject.Find("player_cam");
        camInfo = this.CamInfoSet(camInfo);

    }
	
	// Update is called once per frame
	void Update () {

        camInfo = this.CamInfoRevise(camInfo);
        transform.position = new Vector3(player.transform.position.x + camInfo[0] , player.transform.position.y + 9, player.transform.position.z + camInfo[1]);
        transform.localEulerAngles = new Vector3(camInfo[2], camInfo[3], 0);
   
    }


}
