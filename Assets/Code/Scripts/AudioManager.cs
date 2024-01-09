using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Para cambiar entre escenas

public class AudioManager : MonoBehaviour
{
    //Array para los sonidos y para las m�sicas
    public AudioSource[] sfx, music;

    //Hacemos esta clase(este script) Singleton para poder sacar su informaci�n desde muchos objetos
    //Static es que solo hay uno de este tipo en todo el juego
    public static AudioManager amInstance;//Es el mismo tipo que el script
    //El singleton es m�s apropiado usarlo, cuando vamos a hacer much�simas referencias desde distintos objetos
    private void Awake()
    {
        //Si la referencia no est� llena, la lleno
        if (amInstance == null)
            amInstance = this;//La relleno con todo el contenido de este c�digo
    }

    // Start is called before the first frame update
    void Start()
    {
        //Ponemos la m�sica en marcha
        PlayMusic();
    }

    //M�todo para reproducir sonidos
    public void PlaySFX(int soundToPlay)
    {
        //Si ya se estaba reproduciendo ese sonido, lo paramos
        sfx[soundToPlay].Stop();
        //Reproducimos el sonido pasado por par�metro
        sfx[soundToPlay].Play();
    }

    //M�todo para reproducir la m�sica del juego
    public void PlayMusic()
    {
        //Si estamos en el men� principal
        if (SceneManager.GetActiveScene().name == "MainMenu")
            //Reproducimos la primera m�sica del array
            music[0].Play();
        //Si estamos en el juego
        if (SceneManager.GetActiveScene().name == "Game")
            //Reproducimos la segunda m�sica del array
            music[1].Play();
    }
}
