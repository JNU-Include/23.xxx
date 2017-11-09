using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_AnimationEvent : MonoBehaviour {


	public void OnEnemyAttack()
	{
		GetComponentInParent<M_FSMEnemy> ().OnAttack();
		//ComponentParent OnAttack 
	}

	public void OnPlayerAttack()
	{
		//ComponentParent OnAttack
	}

	public void StartEffect(string effectName)
	{
		//Player Effect Component StartEffect
	}
}
