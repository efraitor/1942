using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable para la velocidad del avi�n
    public float moveSpeed;
    //N�mero de vidas que tiene el jugador
    public int lifes = 3;
    //Referencia al RB
    public Rigidbody2D rb;
    //Referencia a la bala
    public GameObject bullet;
    //Referencia al punto de disparo del avi�n
    public Transform firePoint;
    //Referencia a la UI
    public UIController uiReference;
    //Referencia al GameManager
    public GameManager gmReference;

    //Variable para conocer el m�ximo punto hacia la izquierda
    float leftConstraint;
    //Variable para conocer el m�ximo punto hacia la derecha
    float rightConstraint;
    //Sirve para que la nave desaparezca una vez pasado el borde de la c�mara mas esta cantidad
    float offset = .05f;

    private void Start()
    {
        //Inicializamos la referencia al Rigidbody
        //rb = GetComponent<Rigidbody2D>();
        //Le damos valores a esas restricciones
        //Busca un punto en el espacio de Unity relativo al mismo punto de lo que ve la c�mara
        //Screenwidth es el tama�o de la pantalla de ancho de lo que ve la c�mara
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.05f, 0.0f, 0.0f)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.95f, 0.0f, 0.0f)).x;
    }

    void Update()
    {
        //Movimiento en las 4 direcciones y en diagonal
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpeed;
        //Si la nave se ha salido por la izquierda o la derecha de lo que ve la c�mara
        if (transform.position.x < leftConstraint - offset)
            transform.position = new Vector2(rightConstraint + offset, transform.position.y);
        else if (transform.position.x > rightConstraint + offset)
            transform.position = new Vector2(leftConstraint - offset, transform.position.y);

        //Si pulsamos para disparar una bala
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Crear un objeto es crear una instancia que es una unidad de algo
            //Le pasamos el objeto que queremos que aparezca, en la posici�n y rotaci�n que queremos que aparezca
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            //Sonido al disparar una bala
            AudioManager.amInstance.PlaySFX(0);
        }

        //Reiniciamos la partida al perder las 3 vidas
        if (lifes <= 0)
        {    
            //Llamamos al m�todo que reinicia el juego
            gmReference.ResetGame();
        }    
    }

    //M�todo para saber cuando un objeto se ha metido en el Trigger del jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si se ha metido un enemigo, o una bala enemiga
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet"))
        {
            //Le restamos una vida al jugador
            lifes--;
            //Actualizamos las vidas en la UI
            uiReference.UpdateLifes(lifes);
            if(lifes > 0)
                //Reproducimos el sonido de muerte del jugador
                AudioManager.amInstance.PlaySFX(6);
            //Destruimos la nave enemiga
            Destroy(collision.gameObject);
            //Llamo al m�todo de empezar una nueva vida
            gmReference.AnotherLife();
        }
    }
}
