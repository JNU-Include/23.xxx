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

	protected override void Awake()
	{
		base.Awake ();
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
		} while(!isNewState);
	}

	protected virtual IEnumerator Attack()
	{
		do {
			yield return null;


		} while (!isNewState);
	}

	protected virtual IEnumerator Dead()
	{
		do {
			yield return null;


		} while (!isNewState);
	}

}
