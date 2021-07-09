using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public abstract class BulletPattern : MonoBehaviour
{
    public abstract IEnumerator GenerateBulletPattern(Bullet bullet, Vector2 shootingDirection, Vector2 shootingPoint, Shooter shooter);
    public abstract float GetNumberOfBullets();
}
