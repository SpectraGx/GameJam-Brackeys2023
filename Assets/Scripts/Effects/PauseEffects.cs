using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseEffects : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    
    [SerializeField] float timeFlash = 0.8f;
    
    
    void Awake()
    {
        
    }
    
    void Start()
    {

        StartCoroutine(ScreenTintineo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ScreenTintineo()
    {
        for(;;)
        {
            if (PausePanel.GetComponent<Image>().color != new Color(0.2f, 0.4f, 0.32f, 0.8f))
            {
                PausePanel.GetComponent<Image>().color = new Color(0.2f, 0.4f, 0.32f, 0.8f);
            }
            else
            {
                PausePanel.GetComponent<Image>().color = new Color(0.2f, 0.4f, 0.32f, 0.5f);
            }
            yield return new WaitForSeconds(timeFlash);
        }
    }
}
