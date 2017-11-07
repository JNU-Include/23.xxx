using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public static Enemy instance = null;
    private void Awake()
    {
        instance = this;
    }


    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target = null;
    Animator animator;

    public float e_health;



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            //애니메이션 전환
        }
        else { }
   
    }

    void e_trace()
    {   
        if (pathfinder.destination != transform.position)
        {
            StartCoroutine(UpdatePath());
        }
        else
        {

        }

    }

    void e_attack()
    {

    }

    void e_hit()
    {

    }

    void e_death()
    {

    }




    void Start()
    {
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.1f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
    
}