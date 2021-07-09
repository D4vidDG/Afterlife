using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc : BulletPattern
{
    [SerializeField] [Range(0, 360)] float arcDegrees = 90;
    [SerializeField] float numberOfBullets = 10;
    [SerializeField] float arcRadius = 0;
    [SerializeField] float waitTimeBetweenBullets = 0;

    public override IEnumerator GenerateBulletPattern(Bullet bullet, Vector2 shootingDirection, Vector2 shootingPoint, Shooter shooter)
    {
        List<Bullet> bullets = new List<Bullet>();

        float bulletAngleIncrement = arcDegrees / numberOfBullets;
        float bulletAngle = (-arcDegrees / 2);
        float currentNumberOfBullets = 0;

        while (currentNumberOfBullets < numberOfBullets)
        {
            Vector2 bulletDirection = Quaternion.AngleAxis(bulletAngle, Vector3.forward) * shootingDirection;

            Bullet bulletInstance =
                Object.Instantiate(bullet, shootingPoint + bulletDirection.normalized * arcRadius, Quaternion.identity, null);

            bullets.Add(bulletInstance);


            bulletInstance.SetDirection(bulletDirection);
            bulletInstance.SetShooter(shooter);

            bulletAngle += bulletAngleIncrement;
            currentNumberOfBullets++;
            yield return new WaitForSeconds(waitTimeBetweenBullets);
        }

        foreach (Bullet bulletInstance in bullets)
        {
            bulletInstance.Launch();
        }
    }

    public override float GetNumberOfBullets()
    {
        return numberOfBullets;
    }
}