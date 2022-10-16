
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform soundPoint;
    public Transform soundTransform;
    public LayerMask groundMask, playerMask;
    private Animator anim;
    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //sight state
    public float sightRange;
    public bool inSightRange;

    //sound state
    private float hearRange;
    private bool inHearingRange;
    private int soundMask;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      //  inSightRange = Physics.cast(transform.position, sightRange, playerMask);
        if (!inSightRange) Patroling();
    }
    private void Patroling()
    {
        if (!walkPointSet) 
        {
            SerachWalkPoint();
            anim.SetBool("isMoving" , true);
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            anim.SetBool("isMoving", false);
        } 

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1)
            walkPointSet = false;
    }

    private void SerachWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
            walkPointSet = true;
    }

    private void SoundAlert ()
    {
        inHearingRange = Physics.CheckSphere(transform.position, hearRange, soundMask);
        agent.SetDestination(soundPoint.position);
        transform.LookAt(soundPoint);
    }
    private void OnDrawGizmos()
    {
    }
}
