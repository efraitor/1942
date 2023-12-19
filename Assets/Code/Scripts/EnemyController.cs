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
            //Destruimos la nave
            Destroy(gameObject);
        }
    }
}
