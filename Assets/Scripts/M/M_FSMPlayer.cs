using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_FSMPlayer : M_FSMBase {
	public int currentHP = 100;
	public int maxHP = 100;
	public int exp = 0;
	public int level = 1;
	public int gold = 0;
	public float attack = 10.0f;
	public float attackRange = 1.2f;

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
		} while(!isNewState);
	}

	protected virtual IEnumerator Hurt()
	{
		do {
			yield return null;
		} while(!isNewState);
	}
}
