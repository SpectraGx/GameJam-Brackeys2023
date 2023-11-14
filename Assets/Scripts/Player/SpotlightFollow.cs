using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFollow : MonoBehaviour
{
    [SerializeField] Camera m_Camera;
    
    void Awake()
    {
        if(m_Camera == null) m_Camera = Camera.main;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 mousePos = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
