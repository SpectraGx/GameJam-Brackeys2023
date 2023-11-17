using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnMenu : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    
    void Awake()
    {
        MainMenu.SetActive(false);
    }
    public void TurnMenuOn()
    {
        MainMenu.SetActive(true);
    }
}
