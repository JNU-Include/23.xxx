using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    Animator animator;
    public float e_health;
    public float e_distance = 1;
    public float e_atkSpeed = 0.2f;
    public float e_dieTime = 0.5f;
    public float knockPow = 100;
    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;
    GameObject player;
    GameObject enemy;
    GameObject p_atk;
    private float p_dmg;
    

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "P_atk")
        {
            e_hit();
        }
    }

    void e_trace()
    {   
        target = player.transform;
        animator.SetBool("OnGround", true);
        //animator.SetBool("IsAttack", false);
        //animator.SetBool("IsWalk", true);
        StartCoroutine(UpdatePath());

        
    }

    IEnumerator e_attack()
    {
        animator.SetFloat("Speed", 0);
        animator.SetBool("Attack2", true);
        yield return new WaitForSeconds(e_atkSpeed);
        animator.SetBool("Attack2", false);
        animator.SetFloat("Speed", 1);
        e_trace();
    }

    void e_hit()
    {
        //넉백
        GetComponent<Rigidbody>().AddForce(player.transform.localEulerAngles * knockPow);

        //체력감소
        if(e_health > 0)
        {
            e_health = e_health - p_dmg;
        }
        else if(e_health < 0)
        {
            StartCoroutine(e_death());
        }
    }

    IEnumerator e_death()
    {
        //멈추게 하고
        pathfinder.SetDestination(enemy.transform.position);
        //눕고
        transform.localEulerAngles = new Vector3(90, 0, 0);
        yield return new WaitForSeconds(e_dieTime);
        //파괴
        Destroy(this);
    }




    void Start()
    {
        p_dmg = M_FSMPlayer.instance.attack;
        animator.SetBool("OnGround", false);
        animator.SetFloat("Speed", 1);
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
            if (e_distance > Vector3.Distance(player.transform.position, enemy.transform.position) )
            {
                pathfinder.SetDestination(enemy.transform.position);
                break;
            }
                yield return new WaitForSeconds(refreshRate);
        }
        StartCoroutine(e_attack());
    }
    
}