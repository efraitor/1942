using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Variable para controlar la velocidad de la bala
    public float bulletSpeed;
    //Referencia al RB de la bala
    public Rigidbody2D bRB;

    // Start is called before the first frame update
    void Start()
    {
        //Si la bala es la del jugador
        if(gameObject.CompareTag("Bullet"))
            //Hacemos que la bala avance hacia arriba
            bRB.velocity = new Vector2(0f, bulletSpeed);
        //Si la bala es la del enemigo
        if(gameObject.CompareTag("EnemyBullet"))
            //Hacemos que la bala avance hacia abajo
            bRB.velocity = new Vector2(0f, -bulletSpeed);
        //Destruir�a el objeto al que est� asociado este c�digo pasados 2 segundos
        //Destroy(gameObject, 2f);
    }

    //M�todo de Unity que hace un acci�n cuando se deja de ver el objeto por la c�mara
    void OnBecameInvisible()
    {
        //Destruye el objeto donde est� asociado este c�digo
        Destroy(gameObject);
    }

    //M�todo para saber cuando la bala se choca contra algo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el objeto contra el que colisionamos es una bala o una bala enemiga
        if(collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            //Sonido de impacto de balas entre s�
            AudioManager.amInstance.PlaySFX(4);
            //Se destruye el otro objeto
            Destroy(collision.gameObject);
            //Se destruye este objeto
            Destroy(gameObject);
        }
    }
}
