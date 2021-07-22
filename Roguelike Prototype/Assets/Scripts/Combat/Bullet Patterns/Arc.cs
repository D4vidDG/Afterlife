
using System.Collections;
using UnityEngine;

public class Arc : BulletPattern
{
    [SerializeField] [Range(0, 360)] float arcDegrees = 90;
    [SerializeField] float waitTimeBetweenBullets = 0;
    [SerializeField] float minNumberOfBulletsToShoot;
    [SerializeField] float launchTimeDelay = 0;

    ObjectPool bulletPool;

    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
    }

    public override IEnumerator ShootBulletPattern(ObjectPool bulletPool, Vector2 shootingDirection, Vector2 shootingPoint, LayerMask targetLayer)
    {
        float bulletAngleIncrement = arcDegrees / base.numberOfBullets;
        float bulletAngle = (-arcDegrees / 2);
        float currentNumberOfBullets = 0;

        while (currentNumberOfBullets < numberOfBullets)
        {
            Vector2 bulletDirection = Quaternion.AngleAxis(bulletAngle, Vector3.forward) * shootingDirection;
            Bullet bullet = bulletPool.RequestSubject().GetComponent<Bullet>();

            bullet.SetDirection(bulletDirection);
            bullet.SetTargetLayer(targetLayer);

            bulletAngle += bulletAngleIncrement;
            currentNumberOfBullets++;
            StartCoroutine(LaunchBullet(bullet, launchTimeDelay));
            yield return new WaitForSeconds(waitTimeBetweenBullets);
        }


    }

    private IEnumerator LaunchBullet(Bullet bullet, float launchTimeDelay)
    {
        yield return launchTimeDelay;
        bullet.Launch();
    }
}