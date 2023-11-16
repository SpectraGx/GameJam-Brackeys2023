using TMPro;
using UnityEngine;



public class CambioColor : MonoBehaviour
{
        
    public TextMeshProUGUI text;




    public void ChangeWhiteColor()
    {

        text.color = new Color(0.8490566f,0.8490566f, 0.8490566f);

    }

    public void ChangeGreenColor()
    {

        text.color = new Color(0.2705882f, 0.5607843f, 0.345098f);

    }

    private void OnMouseEnter()
    {
        ChangeWhiteColor();
    }
    private void OnMouseExit()
    {
        ChangeGreenColor();
    }

}


