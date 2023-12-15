using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable para la velocidad del avión
    public float moveSpeed;
    //Referencia al RB
    public Rigidbody2D rb;

    private void Start()
    {
        //Inicializamos la referencia al Rigidbody
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpeed;
    }
}
