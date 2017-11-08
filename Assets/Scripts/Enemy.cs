using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    Animator animator;
    public float e_health;
    public float e_distance = 1;
    public float e_atkSpeed = 0.2f;
    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;
    GameObject player;
    GameObject enemy;

    public static Enemy instance = null;

    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    /*
    private void e_idle()
    {
            if (e_distance > Vector3.Distance(enemy.transform.position, player.transform.position))
            {
                e_trace();
            }
    }
    */

    void e_trace()
    {   
        if (pathfinder.destination != transform.position)
        {
            target = player.transform;
            animator.SetBool("IsWalk", true);
            StartCoroutine(UpdatePath());
        }


    }

    IEnumerator e_attack()
    {
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsAttack", true);
        yield return new WaitForSeconds(e_atkSpeed);
        animator.SetBool("IsAttack", false);
        e_trace();
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
        target = null;
        e_trace();
        
        



    }


    IEnumerator UpdatePath()
    {
        float refreshRate = 0.15f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            if (e_distance < Vector3.Distance(player.transform.position, enemy.transform.position) )
            {
                target = null;
                break;
            }
                yield return new WaitForSeconds(refreshRate);
        }
        StartCoroutine(e_attack());
    }
    
}