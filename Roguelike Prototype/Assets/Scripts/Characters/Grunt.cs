
using Pathfinding;
using UnityEngine;


public class Grunt : MonoBehaviour
{
    [SerializeField] float maxApproachDistance;
    [SerializeField] Weapon weapon;
    [SerializeField] GameObject bodyParticlesPrefab;

    Shooter shooter;
    GameObject player;
    Rigidbody2D myRigidbody;
    AIDestinationSetter destinationSetter;
    AIPath agent;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        agent = GetComponent<AIPath>();
        player = GameObject.FindWithTag("Player");
        myRigidbody = GetComponent<Rigidbody2D>();
        GetComponent<AIDestinationSetter>().target = player.transform;
    }
    private void Start()
    {
        InvokeRepeating("Shoot", 1 / shooter.fireRate, 1 / shooter.fireRate);
    }

    private void Shoot()
    {
        weapon.Shoot(GetVectorToPlayer().normalized, transform.position, shooter);
    }

    private void Update()
    {
        agent.canMove = GetVectorToPlayer().sqrMagnitude > Mathf.Pow(maxApproachDistance, 2);
        if (!agent.canMove) myRigidbody.velocity = Vector2.zero;

    }

    private Vector2 GetVectorToPlayer()
    {
        if (player.gameObject == null) return Vector2.zero;
        return player.transform.position - transform.position;
    }

    public void GenerateBodyParticles()
    {
        Instantiate(bodyParticlesPrefab, transform.position, Quaternion.identity, null);
    }
}