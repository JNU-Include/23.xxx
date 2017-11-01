using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Player : MonoBehaviour {
	//Player Setting 
	public int life;
	Rigidbody rigdbody;

	void Awake()
	{
		rigdbody = GetComponent<Rigidbody> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	// life controll
	public int GetLife()
	{
		return life;
	}
	public void SetLife(int life) 
	{
		this.life = life;
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void PlayerMove()
	{
		
	}
}
