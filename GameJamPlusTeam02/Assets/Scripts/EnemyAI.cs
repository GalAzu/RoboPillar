
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public GameObject bgmObject;
    private BGM bgmScript;
    public NavMeshAgent agent;
    public Transform player;
    public ThirdPersonCharacter character;
    public Transform soundPoint;
    public LayerMask groundMask, playerMask;
    private Animator anim;
    [SerializeField] private Transform sightSphereCast;
    [SerializeField] private Transform backSphereCast;
    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //sight state
    public float sightRange;
    public bool inSightRange;
    private object inBackRange;


    //sound state
    private float hearRange;
    private bool inHearingRange;
    private int soundMask;
    public float caughtDistance;
    public float outOfSightDistance;


    void Awake()
    {
<<<<<<< Updated upstream
        bgmScript = bgmObject.GetComponent<BGM>();
=======
        character = FindObjectOfType<ThirdPersonCharacter>();
>>>>>>> Stashed changes
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<ThirdPersonCharacter>().transform;
      
      
    }

    // Update is called once per frame
    void Update()
    {
        SightAlert();
    }
    private void SightAlert()
    {
        inSightRange = Physics.CheckSphere(sightSphereCast.position, sightRange, playerMask);
        inBackRange = Physics.CheckSphere(backSphereCast.position, sightRange, playerMask);
        if (inSightRange)
        {
            ChasePlayer();
            character.isChased = true;
        }
        if(!inSightRange)
        {
            Patroling();
            character.isPatrol = true;
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
        if(agent.remainingDistance < caughtDistance)
        {
<<<<<<< Updated upstream
           
=======
            Destroy(character.gameObject);
>>>>>>> Stashed changes
            Debug.Log("CAUGHT");
            FMODUnity.RuntimeManager.PlayOneShot("event:/detected or game over");
            bgmScript.musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

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
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(sightSphereCast.position, sightRange);
        Gizmos.DrawWireSphere(backSphereCast.position, sightRange);

    }
    private void SoundAlert()
    {
        inHearingRange = Physics.CheckSphere(transform.position, hearRange, soundMask);
        agent.SetDestination(soundPoint.position);
        transform.LookAt(soundPoint);
    }
}
