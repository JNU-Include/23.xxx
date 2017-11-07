using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {

    public void Quit_Button()
    {
        Invoke("quitgame", .2f);
    }

    void quitgame()
    {
        Application.Quit();
        
    }
}
