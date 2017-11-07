using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {

    }

    public void Start_Button()
    {
        Invoke("startgame", .2f);
    }

    void startgame() {
        Application.LoadLevel("f1");
    }

}