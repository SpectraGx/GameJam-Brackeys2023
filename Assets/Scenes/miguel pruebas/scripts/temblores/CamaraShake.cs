using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraShake : MonoBehaviour
{
    public float intensidad = 1.0f;
    public float duracion = 0.5f;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera()
    {
        noise.m_AmplitudeGain = intensidad;
        Invoke(nameof(StopShaking), duracion);
    }

    private void StopShaking()
    {
        noise.m_AmplitudeGain = 0;
    }
    
}
