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

	M_FSMPlayer m_Player;

	void Awake()
	{
		m_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<M_FSMPlayer> ();
	}
	// Update is called once per frame
	void Update () {
		level.text = m_Player.level.ToString ();
		hpBar.fillAmount = (float)m_Player.currentHP / (float)m_Player.maxHP;
		mpBar.fillAmount = (float)m_Player.currentMP / (float)m_Player.maxMP;
		expBar.fillAmount = ((float)m_Player.exp % 100.0f) / 100.0f;
	}
}
