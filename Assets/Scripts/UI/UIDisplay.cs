using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] GameController GM;
    [SerializeField] TextMeshProUGUI KeysObtained;

   
    void Update()
    {
        KeysObtained.text = GM.KeysObtained + " / " + GM.KeysAmount;
    }
}
