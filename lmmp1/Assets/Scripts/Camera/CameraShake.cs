using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set;  }
    private CinemachineVirtualCamera virtualCamera;
    private float shakeTimer;
    private void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();   
    }
    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlinvirtualCamera = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlinvirtualCamera.m_AmplitudeGain = intensity;
        shakeTimer = time;

    }

    private void Update()
    {
        
        if(shakeTimer <= 0)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlinvirtualCamera = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlinvirtualCamera.m_AmplitudeGain = 0;
        }
        else
        {
            shakeTimer -= Time.deltaTime;
        }
    }
}

