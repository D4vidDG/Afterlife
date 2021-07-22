using System.Collections;
using UnityEngine;



public class Line : BulletPattern
{
    public override IEnumerator ShootBulletPattern(ObjectPool bulletPool, Vector2 shootingDirection, Vector2 shootingPoint, LayerMask targetLayer)
    {
        print("Shoot");
        Bullet bulletInstance = bulletPool.RequestSubject().GetComponent<Bullet>();
        bulletInstance.SetDirection(shootingDirection.normalized);
        bulletInstance.SetTargetLayer(targetLayer);
        bulletInstance.Launch();
        yield return null;
    }
}