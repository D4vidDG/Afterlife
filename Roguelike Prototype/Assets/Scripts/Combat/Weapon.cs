using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Weapon : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] float damagePerBullet;
    [SerializeField] Transform shootingPoint;

    BulletPattern bulletPattern;
    LayerMask enemiesLayer;
    ObjectPool bulletPool;

    private void Start()
    {
        enemiesLayer = LayerMask.GetMask("Enemy");
        print(enemiesLayer.value);
        bulletPool = GetComponent<ObjectPool>();
        bulletPattern = GetComponent<BulletPattern>();
    }

    public void Shoot(Vector2 direction)
    {
        StartCoroutine(bulletPattern.ShootBulletPattern(bulletPool, direction, shootingPoint.position, enemiesLayer));
    }

    public float GetFireRate()
    {
        return fireRate;
    }
}