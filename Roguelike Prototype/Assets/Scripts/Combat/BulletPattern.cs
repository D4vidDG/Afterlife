
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletPattern : MonoBehaviour
{
    [SerializeField] protected float numberOfBullets;

    protected List<Bullet> bullets;

    public abstract IEnumerator ShootBulletPattern(ObjectPool bulletPool, Vector2 shootingDirection, Vector2 shootingPoint, LayerMask targetLayer);
}
