using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MoveUtil : MonoBehaviour {
	
	public static float MoveFrame(CharacterController characterController, Transform target, float moveSpeed, float turnSpeed)
	{
		Transform t = characterController.transform;
		Vector3 dir = target.position - t.position;
		Vector3 dirXZ = new Vector3 (dir.x, 0f, dir.z);
		Vector3 targetPos = t.position + dirXZ;
		Vector3 framePos = Vector3.MoveTowards (t.position, targetPos, moveSpeed * Time.deltaTime);

		characterController.Move (framePos - t.position + Physics.gravity);

		RotateToDir (t, target, turnSpeed);

		return Vector3.Distance (framePos, targetPos);
	}

	//get location, speed 
	public static void RotateToDir(Transform self, Transform target, float turnSpeed)
	{
		Vector3 dir = target.position - self.position;
		Vector3 dirXZ = new Vector3 (dir.x, 0f, dir.z);
		if (dirXZ == Vector3.zero)
			return;

		self.rotation = Quaternion.RotateTowards (self.rotation, Quaternion.LookRotation (dirXZ), turnSpeed * Time.deltaTime);
	}

	public static void RotateToDirBurst(Transform self, Transform target)
	{
		Vector3 dir = target.position - self.position;
		Vector3 dirXZ = new Vector3 (dir.x, 0f, dir.z);

		if (dirXZ == Vector3.zero)
			return;

		self.rotation = Quaternion.LookRotation (dirXZ);
	}

}
