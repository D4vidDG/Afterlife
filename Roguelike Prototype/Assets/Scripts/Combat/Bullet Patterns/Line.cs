using System.Collections;
using UnityEngine;



public class Line : BulletPattern
{
    public override IEnumerable GenerateBulletPattern(ObjectPool bulletPool, Vector2 shootingDirection, Vector2 shootingPoint, LayerMask targetLayer)
    {
        Bullet bulletInstance = Object.Instantiate(bullet, shootingPoint, Quaternion.identity, null);
        bulletInstance.SetDirection(shootingDirection.normalized);
        bulletInstance.SetShooter(shooter);
        bulletInstance.Launch();
        yield return null;
    }
}