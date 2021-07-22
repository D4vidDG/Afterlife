
using UnityEngine;
using Pathfinding;
using System;
using Random = UnityEngine.Random;
using System.Collections;

public class Grunt : MonoBehaviour
{
    [SerializeField] float fovDistance;
    [SerializeField] float maxApproachDistance;
    [SerializeField] float fireRate;
    [SerializeField] Transform shootingPosition;
    [SerializeField] float patrolRadius;
    [SerializeField] float dwellingTime;


    ObjectPool enemiesBullets;
    GameObject player;
    BulletPattern bulletPattern;
    Rigidbody2D myRigidbody;
    AIDestinationSetter destinationSetter;
    AIPath agent;

    float timeSinceShoot;
    Coroutine patrolRoutine;
    Vector2 vectorToPlayer;

    private void Awake()
    {
        agent = GetComponent<AIPath>();
        player = GameObject.FindWithTag("Player");
        bulletPattern = GetComponentInChildren<BulletPattern>();
        myRigidbody = GetComponent<Rigidbody2D>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        enemiesBullets = GameObject.FindWithTag("Enemy Pool").GetComponent<ObjectPool>();
    }

    private void Start()
    {
        if (shootingPosition == null) shootingPosition = transform;
    }

    private void Update()
    {
        timeSinceShoot += Time.deltaTime;
        vectorToPlayer = GetVectorToPlayer();

        if (IsOnFOV())
        {
            destinationSetter.target = player.transform;
            StopCoroutine(patrolRoutine);
            AttackAndApproach(vectorToPlayer);
        }
        else
        {
            destinationSetter.target = null;
            agent.canMove = true;
            timeSinceShoot = 0;
            patrolRoutine = StartCoroutine(Patrol());
        }

        if (!agent.canMove) myRigidbody.velocity = Vector2.zero;
    }

    private bool IsOnFOV()
    {
        return vectorToPlayer.sqrMagnitude < Mathf.Pow(fovDistance, 2);
    }

    private IEnumerator Patrol()
    {
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        Vector2 targetPosition = (Vector2)transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * patrolRadius;
        agent.destination = targetPosition;

        yield return new WaitUntil(() => { return agent.targetReached; });
        StartCoroutine(Patrol());
    }

    private void AttackAndApproach(Vector2 vectorToPlayer)
    {
        agent.canMove = vectorToPlayer.sqrMagnitude > Mathf.Pow(maxApproachDistance, 2);

        if (timeSinceShoot > (1 / fireRate))
        {
            bulletPattern.ShootBulletPattern(enemiesBullets, GetVectorToPlayer(), shootingPosition.position, player.layer);
            timeSinceShoot = 0;
        }
    }

    private Vector2 GetVectorToPlayer()
    {
        if (player.gameObject == null) return Vector2.zero;
        return player.transform.position - transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fovDistance);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, patrolRadius);
    }
}