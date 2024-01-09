using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable para la velocidad del avión
    public float moveSpeed;
    //Número de vidas que tiene el jugador
    public int lifes = 3;
    //Referencia al RB
    public Rigidbody2D rb;
    //Referencia a la bala
    public GameObject bullet;
    //Referencia al punto de disparo del avión
    public Transform firePoint;
    //Referencia a la UI
    public UIController uiReference;
    //Referencia al GameManager
    public GameManager gmReference;

    private void Start()
    {
        //Inicializamos la referencia al Rigidbody
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Movimiento en las 4 direcciones y en diagonal
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpeed;

        //Si pulsamos para disparar una bala
        if (Input.GetKeyDown(KeyCode.Space))
            //Crear un objeto es crear una instancia que es una unidad de algo
            //Le pasamos el objeto que queremos que aparezca, en la posición y rotación que queremos que aparezca
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);

        //Reiniciamos la partida al perder las 3 vidas
        if(lifes <= 0)
            //Llamamos al método que reinicia el juego
            gmReference.ResetGame();
    }

    //Método para saber cuando un objeto se ha metido en el Trigger del jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si se ha metido un enemigo
        if (collision.CompareTag("Enemy")) 
        {
            //Le restamos una vida al jugador
            lifes--;
            //Actualizamos las vidas en la UI
            uiReference.UpdateLifes(lifes);
            //Destruimos la nave enemiga
            Destroy(collision.gameObject);
            //Llamo al método de empezar una nueva vida
            gmReference.AnotherLife();
        }
    }
}
