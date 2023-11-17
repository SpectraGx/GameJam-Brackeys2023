using UnityEngine;
using Cinemachine;
using UnityEngine.UIElements;

public class ScreenShakeV2 : MonoBehaviour
{
    public static ScreenShakeV2 Instance { get; private set; }
    private CinemachineVirtualCamera virtualCamera;
    private float force;
    private float ShakeTimer;

    [SerializeField] GameController GM;
    [SerializeField] float constanIntensity;

    void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    
    public void ShakeCamera(float intensity, float timer)
    {
        force = intensity;
        CinemachineBasicMultiChannelPerlin virtualCameraChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        virtualCameraChannel.m_AmplitudeGain = force;

        ShakeTimer = timer;
    }


    private void Update()
    {
        if(ShakeTimer > 0)
        {
            ShakeTimer -= Time.deltaTime;
        }
        if (ShakeTimer <= 0f)
        {
            force = 0f;
            CinemachineBasicMultiChannelPerlin virtualCameraChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            virtualCameraChannel.m_AmplitudeGain = force;
        }
        if(GM.isBossActive && force < constanIntensity)
        {
            CinemachineBasicMultiChannelPerlin virtualCameraChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            virtualCameraChannel.m_AmplitudeGain = constanIntensity;
        }
    }
}
