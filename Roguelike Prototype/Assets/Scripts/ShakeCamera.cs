using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField] float shakeIntensity;
    [SerializeField] float shakeTime;

    public void Shake()
    {
        CinemachineShake.Instance.ShakeCamera(shakeIntensity, shakeTime);
    }
}
