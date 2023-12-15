using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Librer�a que nos permite cambiar de escenas

public class MainMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Si pulso esta tecla hace el m�todo que me lleva al juego
        if (Input.GetKeyDown(KeyCode.Return))
            StartGame();
    }

    //M�todo que me lleva al juego
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
