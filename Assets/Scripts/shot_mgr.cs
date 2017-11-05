using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_mgr : MonoBehaviour {
    //싱글턴
    public static shot_mgr instance = null;
    private void Awake()
    {
        instance = this;
    }

    //보스 패턴 스위치
    public bool shot_bullet_b = false;
    public bool shot_frame_b = false;
    public bool shot_beam_b = false;
    public bool swing_weapon = false;
    public bool summon_soldier = false;

    //보스 패턴 데미지



    //보스 패턴 속도

    //보스 패턴 함수

    
    //



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
