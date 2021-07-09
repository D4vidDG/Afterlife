using System.Collections;
using UnityEngine;



public class Line : BulletPattern
{
    public override IEnumerator GenerateBulletPattern(Bullet bullet, Vector2 shootingDirection, Vector2 shootingPoint, Shooter shooter)
    {
        Bullet bulletInstance = Object.Instantiate(bullet, shootingPoint, Quaternion.identity, null);
        bulletInstance.SetDirection(shootingDirection.normalized);
        bulletInstance.SetShooter(shooter);
        bulletInstance.Launch();
        yield return null;
    }

    public override float GetNumberOfBullets()
    {
        return 1;
    }
}