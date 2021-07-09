using System;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] float knockBack;
    [SerializeField] float maxLifeTime = 5f;

    Shooter shooter;
    Rigidbody2D myRigidBody;
    Vector2 direction;
    float lifeTime;

    bool launched = false;


    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            Destroy(gameObject);
        }

    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction.normalized;
    }

    public void SetShooter(Shooter shooter)
    {
        if (shooter == null) return;
        this.shooter = shooter;
    }

    public void Launch()
    {
        myRigidBody.velocity = direction.normalized * speed;
        launched = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.CompareTag("Attract")) return;

        if (shooter != null && other.gameObject.CompareTag(shooter.tag)) return;
        if (other.TryGetComponent<Bullet>(out Bullet bullet)) return;
        if (!launched) return;
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage, false);
        }
        Destroy(gameObject);
    }
}