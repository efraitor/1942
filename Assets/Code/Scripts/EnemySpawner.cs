using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //La jarra de agua. Rellena el contador
    public float spawnTime;
    //El contador de tiempo entre spawns
    private float spawnCounter;

    //Referencia a la nave enemiga
    public GameObject smallEnemy;

    // Start is called before the first frame update
    void Start()
    {
        //Iniciamos el contador
        spawnCounter = spawnTime;//Rellenamos el contador
    }

    // Update is called once per frame
    void Update()
    {
        //Si el contador de spawn no est� vac�o
        if(spawnCounter > 0)
        {
            //Le restamos al contador 1 cada segundo
            spawnCounter -= Time.deltaTime;
        }
        //Si el contador est� vac�o
        else
        {
            //Debug.Log(spawnCounter);
            SpawnEnemy();
            //Reiniciamos el contador para que empiece de nuevo
            spawnCounter = spawnTime;
        }

    }

    public void SpawnEnemy()
    {
        //Cogemos un n�mero aleatorio entre esos dos valores
        float xPosition = Random.Range(-1.0f, 1.0f);
        Debug.Log(xPosition);
        //Hacemos aparecer una nave, en la posici�n del spawner m�s una posici�n aleatoria en X, y con la rotaci�n de la nave
        Instantiate(smallEnemy, transform.position + new Vector3(xPosition, 0f, 0f), smallEnemy.transform.rotation);
    }
}
