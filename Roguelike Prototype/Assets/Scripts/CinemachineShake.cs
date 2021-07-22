
using UnityEngine;
using System;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{

    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;

    internal void ShakeCamera(float shakeIntensity, object shakeTime)
    {
        throw new NotImplementedException();
    }

    private float shakeTimerTotal;
    private float startingIntensity;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(startingIntensity, 0f, 1 - shakeTimer / shakeTimerTotal);
        }
    }

}
