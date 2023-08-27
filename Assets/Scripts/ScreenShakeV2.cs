using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShakeV2 : MonoBehaviour
{
    public static ScreenShakeV2 Instance { get; private set; }
    private CinemachineVirtualCamera virtualCamera;
    private float ShakeTimer;
    void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    
    public void ShakeCamera(float intensity, float timer)
    {
        CinemachineBasicMultiChannelPerlin virtualCameraChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        virtualCameraChannel.m_AmplitudeGain = intensity;

        ShakeTimer = timer;
    }

    private void Update()
    {
        if(ShakeTimer > 0)
        ShakeTimer -= Time.deltaTime;
        if (ShakeTimer <= 0f)
        {
            CinemachineBasicMultiChannelPerlin virtualCameraChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            virtualCameraChannel.m_AmplitudeGain = 0f;
        }
    }
}
