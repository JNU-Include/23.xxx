using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_ControllerMove : MonoBehaviour {

	public float moveSpeed = 3.0f;
	public float turnSpeed = 360.0f;

	public bool isMoveState = false;


	CharacterController _cc;


	Vector3 destination;

	Transform movePoint;


	void Awake ()
	{
		_cc = GetComponent<CharacterController> ();

		movePoint = GameObject.FindGameObjectWithTag ("MovePoint").transform;
		movePoint.gameObject.SetActive (false);
	}


	void Update ()
	{

		if (Input.GetMouseButtonDown (0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;


			if(Physics.Raycast(ray, out hitInfo, 100f))
			{
				destination = hitInfo.point;
				isMoveState = true;

				movePoint.position = hitInfo.point;
				movePoint.gameObject.SetActive(true);
			}
		}

		if (isMoveState)
		{

			Vector3 moveDir = destination - transform.position;
			Vector3 dirXZ = new Vector3(moveDir.x, 0, moveDir.z);
			Vector3 targetPos = transform.position + dirXZ;

			Vector3 framePos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
			Vector3 frameDir  = framePos - transform.position;

			_cc.Move(frameDir + Physics.gravity);


			transform.rotation = Quaternion.RotateTowards(transform.rotation, 
				Quaternion.LookRotation(frameDir), 
				turnSpeed * Time.deltaTime);



			if(framePos == targetPos)
			{
				isMoveState = false;
				movePoint.gameObject.SetActive(false);
			}
		}
	}



}
