using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class M_FSMEnemy : M_FSMBase {

	public float walkSpeed = 1.0f;
	public float runSpeed = 2.0f;
	public float turnSpeed = 10.0f;
	public int currentHP = 50;
	public int maxHP = 50;
	public int level = 1;
	public float attack = 5.0f;
	public float attackRange = 1.0f;
	public float restTime = 1.5f;

	public Transform waypoint;
	protected Transform[] wayPoints;

	Transform player;
	M_FSMPlayer m_player;
	Camera sight;

	protected override void Awake()
	{
		base.Awake ();

		player = GameObject.FindGameObjectWithTag ("Player").transform;
		m_player = player.GetComponent<M_FSMPlayer> ();

		//Camera Data ==> sight 
		sight = GetComponentInChildren<Camera> ();
	}

	bool Detection()
	{
		Plane[] ps = GeometryUtility.CalculateFrustumPlanes (sight);
		return GeometryUtility.TestPlanesAABB (ps, m_player.GetComponent<CharacterController>().bounds);
	}


	protected override void OnEnable()
	{
		wayPoints = waypoint.GetComponentsInChildren<Transform> ();

		base.OnEnable ();
	}

	protected override IEnumerator Idle()
	{
		float _t = 0;

		do {
			yield return null;
			_t += Time.deltaTime;

			if (_t >= restTime) {
				SetState (M_PlayerState.Run);
				break;
			}
			if(Detection())
			{
				SetState(M_PlayerState.AttackRun);
				break;
			}
		} while(!isNewState);
	}
		

	protected virtual IEnumerator Run()
	{
		Transform target = wayPoints [Random.Range (0, wayPoints.Length)];

		do {
			yield return null;

			if (M_MoveUtil.MoveFrame (characterController, target, walkSpeed, turnSpeed) == 0) {
				SetState (M_PlayerState.Idle);
				break;
			}
			if(Detection())
			{
				SetState(M_PlayerState.AttackRun);
				break;
			}
		} while(!isNewState);
	}

	protected virtual IEnumerator Attack()
	{
		do {
			yield return null;

			if(Vector3.Distance(transform.position, player.position) > attackRange)
			{
				SetState(M_PlayerState.AttackRun);
				break;
			}


		} while (!isNewState);
	}

	protected virtual IEnumerator AttackRun()
	{
		do {
			yield return null;
			if (M_MoveUtil.MoveFrame (characterController, player, runSpeed, turnSpeed) <= attackRange) {
				SetState (M_PlayerState.Attack);
				break;
			}
			if(!Detection())
			{
				SetState(M_PlayerState.Idle);	
			}
		} while(!isNewState);


	}
	protected virtual IEnumerator Dead()
	{
		do {
			yield return null;


		} while (!isNewState);
	}

}
