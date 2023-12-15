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
        //Destruir�a el objeto al que est� asociado este c�digo pasados 2 segundos
        //Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo de Unity que hace un acci�n cuando se deja de ver el objeto por la c�mara
    void OnBecameInvisible()
    {
        //Destruye el objeto donde est� asociado este c�digo
        Destroy(gameObject);
    }
}
