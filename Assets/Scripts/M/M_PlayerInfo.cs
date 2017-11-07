using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_PlayerInfo : MonoBehaviour {

	public Text hp;
	public Text mp;
	public Text level;
	public Image hpBar;
	public Image mpBar;
	public Image expBar;

	M_FSMPlayer mPlayer;

	void Awake()
	{
		mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<M_FSMPlayer>();
	}
	// Update is called once per frame
	void Update () {
//		level.text = mPlayer.level.ToString ();
		Debug.Log(mPlayer.level.ToString());
		level.text = "99";
		hpBar.fillAmount = (float)mPlayer.currentHP / (float)mPlayer.maxHP;
		mpBar.fillAmount = (float)mPlayer.currentMP / (float)mPlayer.maxMP;
		expBar.fillAmount = ((float)mPlayer.exp % 100.0f) / 100.0f;
	}
}
