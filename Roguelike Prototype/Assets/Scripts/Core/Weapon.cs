using System;
using UnityEngine;
public class Weapon : MonoBehaviour
{

    [SerializeField] Bullet bullet;
    [SerializeField] float fireRate;
    [SerializeField] float damagePerBullet;
    [SerializeField] BulletPattern bulletPattern;

    public void Shoot(Vector2 shootingDirection, Vector2 shootingPoint, Shooter shooter)
    {
        if (bulletPattern == null) bulletPattern = GetComponent<BulletPattern>();
        shooter.StartCoroutine(bulletPattern.GenerateBulletPattern(bullet, shootingDirection, shootingPoint, shooter));
    }

    public float GetFireRate()
    {
        return fireRate;
    }
    public float GetWeaponAutoDamage()
    {
        return damagePerBullet * bulletPattern.GetNumberOfBullets();
    }
}