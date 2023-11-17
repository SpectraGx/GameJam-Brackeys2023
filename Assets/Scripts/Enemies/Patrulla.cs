using UnityEngine;

public class Patrulla : MonoBehaviour
{
    [SerializeField] GameController GM;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] public Transform[] puntosMovimientos;

    [SerializeField] private float distanciaMinima;

    public int siguientePaso = 0;
    public bool OnChase = false;


    private void Start()
    {

        Girar();

    }


    private void Update()
    {
        Girar();
        if(!OnChase)
        {
            transform.localPosition = Vector3.MoveTowards(transform.position, puntosMovimientos[siguientePaso].position, velocidadMovimiento * Time.deltaTime * GM.GameTime);


            if(Vector2.Distance(transform.localPosition, puntosMovimientos[siguientePaso].position) < distanciaMinima)
            {

                siguientePaso += 1;
                if (siguientePaso >= puntosMovimientos.Length)
                {
                    siguientePaso = 0;
                }
            }
        }

    }

    public void Girar() 
    {

        if((puntosMovimientos[siguientePaso].position.x > transform.position.x && transform.localScale.x != -1) || (puntosMovimientos[siguientePaso].position.x < transform.position.x && transform.localScale.x != 1))
        {
            Vector3 transformScale = transform.localScale;
            transformScale.x *= -1;
            transform.localScale = transformScale;
        }

    }
}
