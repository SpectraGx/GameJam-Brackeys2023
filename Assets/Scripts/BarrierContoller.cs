using Unity.VisualScripting;
using UnityEngine;

public class BarrierContoller : MonoBehaviour
{
    [SerializeField] GameObject Barrier;

    [SerializeField] GameController GM;

    void Update()
    {
        if(GM.KeysObtained == GM.KeysAmount)
        {
            Barrier.SetActive(false);
        }
    }
    
}
