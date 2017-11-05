using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_FSMPlayer : M_FSMBase {
	public int currentHP = 100;
	public int maxHP = 100;
	public int currentMP = 50;
	public int maxMP = 50;
	public int exp = 0;
	public int level = 1;
	public int gold = 0;
	public float attack = 10.0f;
	public float attackRange = 1.2f;
	public float moveSpeed = 3.0f;
	public float turnSpeed = 360.0f;

	public Transform movePoint;
	public Transform attackPoint;

	int layerMask;

	public string clickLayer = "Click";
	public string blockLayer = "Block";
	public string enemyLayer = "Enemy";

	protected override void Awake()
	{
		base.Awake ();

		movePoint = GameObject.FindGameObjectWithTag ("MovePoint").transform;
		movePoint.gameObject.SetActive (false);

		attackPoint = GameObject.FindGameObjectWithTag ("AttackPoint").transform;
		attackPoint.gameObject.SetActive (false);

		layerMask = LayerMask.GetMask (clickLayer, blockLayer, enemyLayer);

	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo, 100f, layerMask)) 
			{
				int layer = hitInfo.transform.gameObject.layer;
				if (layer == LayerMask.NameToLayer (clickLayer)) {
					Vector3 dest = hitInfo.point;
					movePoint.transform.position = dest;
					SetState (M_PlayerState.Run);
					movePoint.gameObject.SetActive (true);
					attackPoint.gameObject.SetActive (true);
				} 
				else if (layer == LayerMask.NameToLayer (enemyLayer)) {
					attackPoint.SetParent (hitInfo.collider.transform);
					attackPoint.transform.localPosition = Vector3.zero;
					attackPoint.gameObject.SetActive (true);
					movePoint.gameObject.SetActive (false);
					SetState (M_PlayerState.AttackRun);
				} else if (layer == LayerMask.NameToLayer (blockLayer)) {
				
				}
			}
		}
	}

	protected override IEnumerator Idle()
	{
		do {
			yield return null;
		} while(!isNewState);
	}

	protected virtual IEnumerator Jump()
	{
		do {
			yield return null;
		} while(!isNewState);
	}

	protected virtual IEnumerator Attack()
	{
		do {
			yield return null;

		} while(!isNewState);
	}

	protected virtual IEnumerator Dead()
	{
		do {
			yield return null;
		} while(!isNewState);
	}

	protected virtual IEnumerator Skill1()
	{
		do {
			yield return null;

		} while(!isNewState);
	}

	protected virtual IEnumerator Run()
	{
		do {
			yield return null;
			if(M_MoveUtil.MoveFrame(characterController, movePoint, moveSpeed, turnSpeed) == 0)
			{
				movePoint.gameObject.SetActive(false);
				SetState(M_PlayerState.Idle);
				break;
			}

		} while(!isNewState);
	}

	protected virtual IEnumerator AttackRun()
	{
		do {
			yield return null;	
			if(M_MoveUtil.MoveFrame(characterController, attackPoint, moveSpeed, turnSpeed) <= attackRange)
			{
				movePoint.gameObject.SetActive(false);
				SetState(M_PlayerState.Attack);
				break;
			}
		} while(!isNewState);
	}

	protected virtual IEnumerator Hurt()
	{
		do {
			yield return null;
		} while(!isNewState);
	}
}
