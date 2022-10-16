
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
   public GameObject bgm;
    private BGM bgmscript;
    public NavMeshAgent agent;
    public Transform player;
    public Transform soundPoint;
    public LayerMask groundMask, playerMask;
    private Animator anim;
    [SerializeField] private Transform sightSphereCast;
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
    public float caughtDistance;
    public float outOfSightDistance;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<ThirdPersonCharacter>().transform;
        bgmscript = bgm.GetComponent<BGM>();
    }

    // Update is called once per frame
    void Update()
    {
        SightAlert();
       
    }
    private void SightAlert()
    {
        inSightRange = Physics.CheckSphere(sightSphereCast.position, sightRange, playerMask);
        if (inSightRange)
        {
            ChasePlayer();
            bgmscript.MusicParameter();
        }
        if (!inSightRange)
        {
            Patroling();
            {
                bgmscript.musicInst.setParameterByName("Danger", 0f, false);
            }
        }
    }
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SerachWalkPoint();
            anim.SetBool("isMoving", true);
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
    private void ChasePlayer()
    {
        print("CHASE PLAYER");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), Time.deltaTime);
        


        agent.SetDestination(player.position);
        if(agent.remainingDistance < 7)
        {
            //ADD SFX FOR PLAYER DEATH
            Debug.Log("CAUGHT");
        }

    }


private void SerachWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
            walkPointSet = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(sightSphereCast.position, sightRange);
    }
    private void SoundAlert()
    {
        inHearingRange = Physics.CheckSphere(transform.position, hearRange, soundMask);
        agent.SetDestination(soundPoint.position);
        transform.LookAt(soundPoint);
    }
}
