using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_StopEffect : MonoBehaviour {

	public float stopTime = 1.0f;

	void OnEnable()
	{
		StartCoroutine (TimeStop ());
	}

	IEnumerator TimeStop()
	{
		yield return new WaitForSeconds (stopTime);
		gameObject.SetActive (false);
	}

}
