using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Referencia al Rigidbody de la nave enemiga
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //La nave se mueve
        rb.velocity = Vector2.down; //Vector.down = new Vector2(0, -1)
        //Destruiría el objeto al que está asociado este código pasados 10 segundos
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método que detecta cuando un objeto se mete dentro del trigger de la nave enemiga
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si es una bala
        if (collision.CompareTag("Bullet"))
        {
            //Destruimos la bala
            Destroy(collision.gameObject);
            //Destruimos la nave
            Destroy(gameObject);
        }
    }
}
