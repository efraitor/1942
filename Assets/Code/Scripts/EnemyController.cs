using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Referencia al Rigidbody de la nave enemiga
    public Rigidbody2D rb;
    //Referencia a las balas enemigas
    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        //La nave se mueve
        //rb.velocity = Vector2.down; //Vector.down = new Vector2(0, -1)
        //Cogemos un n�mero aleatorio entre esos dos valores
        float speed = Random.Range(.5f, 1.0f);
        //La nave se mueve hacia abajo
        rb.velocity = new Vector2(0f, -speed);
        //Disparamos balas
        //InvokeRepeating(nombre del m�todo, tiempo hasta la primera vez, tiempo entre veces
        InvokeRepeating("Shoot", .5f, 1f);
        //Destruir�a el objeto al que est� asociado este c�digo pasados 10 segundos
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo que detecta cuando un objeto se mete dentro del trigger de la nave enemiga
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si es una bala
        if (collision.CompareTag("Bullet"))
        {
            //Destruimos la bala
            Destroy(collision.gameObject);
            //Sonido de cuando muere una nave enemiga
            AudioManager.amInstance.PlaySFX(8);
            //Destruimos la nave
            Destroy(gameObject);
        }
    }

    //M�todo para disparar balas
    public void Shoot()
    {
        //Creamos una bala, en la posici�n frente a la nave, con la rotaci�n de la bala
        Instantiate(enemyBullet, new Vector2(transform.position.x, transform.position.y - .1f), enemyBullet.transform.rotation);
        //Sonido al disparar una bala
        AudioManager.amInstance.PlaySFX(0);
    }
}
