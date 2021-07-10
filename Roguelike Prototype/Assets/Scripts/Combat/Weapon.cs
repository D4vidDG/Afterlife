using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Weapon : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] float damagePerBullet;
    [SerializeField] BulletPattern bulletPattern;
    [SerializeField] Transform shootingPoint;

    LayerMask enemiesLayer;
    ObjectPool bulletPool;

    private void Start()
    {
        enemiesLayer = LayerMask.GetMask("Enemy");
        bulletPool = GetComponent<ObjectPool>();
    }

    public IEnumerator Shoot()
    {
        bulletPattern.GenerateBulletPattern(bulletPool, transform.right, shootingPoint));
    }

    public float GetFireRate()
    {
        return fireRate;
    }
}