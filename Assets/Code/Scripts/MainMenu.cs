using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Librería que nos permite cambiar de escenas

public class MainMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Si pulso esta tecla hace el método que me lleva al juego
        if (Input.GetKeyDown(KeyCode.Return))
            StartGame();
    }

    //Método que me lleva al juego
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
