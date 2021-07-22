using System;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] float knockBack;
    [SerializeField] float maxLifeTime = 5f;

    Rigidbody2D myRigidBody;

    float lifeTime;
    Vector2 direction;

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
            gameObject.SetActive(false);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void SetTargetLayer(LayerMask layer)
    {
        gameObject.layer = (int)Mathf.Log(layer.value);
    }

    public void Launch()
    {
        myRigidBody.velocity = direction.normalized * speed;
        launched = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!launched) return;
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }
        gameObject.SetActive(false);
    }
}