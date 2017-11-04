using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_EffectsManager : MonoBehaviour {
	public List<Transform> effects;
	// Use this for initialization
	public void StartEffect(string effectName)
	{
		for (int i = 0; i < effects.Count; i++) 
		{
			if (effects [i].name.CompareTo (effectName) == 0) 
			{
				effects [i].gameObject.SetActive (false);
				effects [i].gameObject.SetActive (true);
				break;
			}
		}
	}
}
