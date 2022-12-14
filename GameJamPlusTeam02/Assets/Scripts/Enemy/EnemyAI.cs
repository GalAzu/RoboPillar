
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnemyAI : MonoBehaviour
{

    public GameObject bgmObject;
    public NavMeshAgent agent;
    public Transform player;
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

    //state stats
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
    }
    void Update()
    {
        AIstate();
    }
    private void AIstate()
    {
        inSightRange = Physics.CheckSphere(sightSphereCast.position, sightRange, playerMask);
        inBackRange = Physics.CheckSphere(backSphereCast.position, sightRange, playerMask);
        if (inSightRange) ChasePlayer();
        if (!inSightRange) Patroling();
    }
    private void Patroling()
    {
        if (!walkPointSet)
        {
            AudioManager.instance.SafeZone();
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
        AudioManager.instance.Danger();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), Time.deltaTime);
        agent.SetDestination(player.position);
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            GameManager.instance.GameOver();
            FMODUnity.RuntimeManager.PlayOneShot("event:/detected or game over");
            AudioManager.instance.musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        }
    }
}
