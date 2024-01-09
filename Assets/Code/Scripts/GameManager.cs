using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Librería para cambiar entre escenas

public class GameManager : MonoBehaviour
{
    //Referencia al jugador
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Reinicia el juego
    public void ResetGame()
    {
        //Carga la misma escena en la que estamos
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Jugar otra nueva vida
    public void AnotherLife()
    {
        //Llamamos a la corrutina
        StartCoroutine(AnotherLifeCo());
    }

    //Corrutina para cuando jugamos otra vida
    private IEnumerator AnotherLifeCo()
    {
        //Desactivamos al jugador
        player.SetActive(false);
        //Ponemos al jugador en la posición de origen
        player.transform.position = new Vector2(0f, -1f);
        //Esperamos un tiempo en segundos(hace una pausa de 2 seg)
        yield return new WaitForSeconds(2f);
        //Reactivamos al jugador
        player.SetActive(true);
    }
}
