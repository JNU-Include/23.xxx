using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Move : MonoBehaviour {
	UnityEngine.AI.NavMeshAgent navAgent;
	Transform movePoint;


	void Awake () {

		navAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		movePoint = GameObject.FindGameObjectWithTag ("MovePoint").transform;

	}


	void Update () {

		Vector3 pos = Input.mousePosition;

		//캐릭터가 목표지점에 도착하면 movePoint 를 비활성화한다.
		if (navAgent.remainingDistance == 0.0f)
		{
			movePoint.gameObject.SetActive(false);
		}


		if (Input.GetMouseButtonDown (0))
		{

			Ray ray;


			ray = Camera.main.ScreenPointToRay(pos);
			RaycastHit hitInfo;



			if(Physics.Raycast(ray, out hitInfo))
			{

				//hitInpo 좌표로 movePoint 좌표를 변경한다.
				movePoint.position = hitInfo.point;
				movePoint.gameObject.SetActive(true);

				navAgent.SetDestination(hitInfo.point);
			}
		}
	}



}
