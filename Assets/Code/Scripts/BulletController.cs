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
        //Hacemos que la bala avance
        bRB.velocity = new Vector2(0f, bulletSpeed);
        //Destruiría el objeto al que está asociado este código pasados 2 segundos
        //Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método de Unity que hace un acción cuando se deja de ver el objeto por la cámara
    void OnBecameInvisible()
    {
        //Destruye el objeto donde está asociado este código
        Destroy(gameObject);
    }
}
