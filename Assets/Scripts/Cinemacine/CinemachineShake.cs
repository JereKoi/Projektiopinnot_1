using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVritualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntesity;

    private void Awake()
    {
        Instance = this;
        cinemachineVritualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void shakeCamera(float intesity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVritualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intesity;

        startingIntesity = intesity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        shakeTimer -= Time.deltaTime;
        if (shakeTimer <= 0f)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
           cinemachineVritualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
            Mathf.Lerp(startingIntesity, 0f, (1 - (shakeTimer / shakeTimerTotal)));
        }
    }
}
