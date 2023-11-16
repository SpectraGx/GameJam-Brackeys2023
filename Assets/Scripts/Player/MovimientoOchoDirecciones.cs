using UnityEngine;


public class MovimientoOchoDirecciones : MonoBehaviour
{

    [SerializeField] InputSystem inputSystem;
    [SerializeField] GameController GM;
    Rigidbody2D rb;
    public float speed = 5f;


    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        GM.currentSpeed = GM.maxSpeed;
    }

    

    void Update()
    {
        Inputs();
        

        
    }

    void Inputs()
    {
        inputSystem.xMove = Input.GetAxis("Horizontal");
        inputSystem.yMove = Input.GetAxis("Vertical");

 
        inputSystem.moveL = Input.GetKey(KeyCode.A);
        inputSystem.moveR = Input.GetKey(KeyCode.D);
        inputSystem.moveD = Input.GetKey(KeyCode.S);
        inputSystem.moveU = Input.GetKey(KeyCode.W);

        rb.velocity = new Vector2(inputSystem.xMove * GM.currentSpeed * GM.GameTime, inputSystem.yMove * GM.currentSpeed * GM.GameTime);
    }

    
}


