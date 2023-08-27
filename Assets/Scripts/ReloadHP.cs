using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadHP : MonoBehaviour
{
    public FloatVariable HP;
    public void ReloadLives()
    {
        HP.floatValue = 3;
    }
}
