using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mse_slow_effect : MonoBehaviour
{

    //원하는 지형에 넣으면 밟을때 감속효과 생김
    //trigger 걸린 오브젝트에 넣어도 감속효과 생김
    public bool slow = true;
    GameObject player;
    public float slowRate = 0.3f; //slowRate 로 감속률 조정
    float originSpeed;
    float loseSpeed; // 감속으로 잃은 속력량
    public float slowTime = 1f; //감속 지속시간

    //감속 걸림
    private void actSlow()
    {

        float originSpeed = M_FSMPlayer.instance.moveSpeed;

        if (slow == true)
        {
            loseSpeed = originSpeed * slowRate;
            originSpeed *= (1 - slowRate);
            Debug.Log(originSpeed);
            M_FSMPlayer.instance.getSpeed(originSpeed);
            slow = false;
        }
    }

    //감속 풀림
    IEnumerator SlowPTime(float DelayTime)
    {
        yield return new WaitForSeconds(DelayTime);
        float originSpeed = M_FSMPlayer.instance.moveSpeed;
        originSpeed = originSpeed + loseSpeed;
        M_FSMPlayer.instance.getSpeed(originSpeed);
        slow = true;

    }


    private void OnCollisionStay(Collision collision) // 밟을때 감속 관련 코드
    {
        if (collision.gameObject.tag == "Player")
        {
            actSlow();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(SlowPTime(slowTime));
        }

    }


    private void OnTriggerStay(Collider other) //trigger체크된 뚫고 지나가는 투사체에 활용
    {
        if (other.gameObject.tag == "Player")
        {
            actSlow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SlowPTime(slowTime));
        }
    }

}

