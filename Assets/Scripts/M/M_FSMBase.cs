using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class M_FSMBase : MonoBehaviour {
	public CharacterController characterController;
	public Animator anim;
	public M_PlayerState PCState;
	public bool isNewState;

	protected virtual void Awake()
	{
		characterController = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}

	protected virtual void OnEnable() 
	{
		PCState = M_PlayerState.Idle;
		StartCoroutine(FSMMain());
	}

	IEnumerator FSMMain()
	{
		while (true) {
			isNewState = false;
			yield return StartCoroutine (PCState.ToString ());
		}
	}

	public void SetState(M_PlayerState newState)
	{
		isNewState = true;
		PCState = newState;
		anim.SetInteger ("state", (int)PCState);
	}

	protected virtual IEnumerator Idle()
	{
		do {
			yield return null;
		} while(!isNewState);
	}
}
