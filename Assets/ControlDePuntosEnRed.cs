using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class ControlDePuntosEnRed : MonoBehaviourPunCallbacks,IPunObservable
{

    public InputField PlayerInput;
    public InputField EnemigoInput;
    public Text informacion;

    //referecia a los textos de la escena
    public Text JugadorText;
    public Text enemigoREDText;
    public Text enemigoText;
    public Text jugadorREDText;


    //valores para modificar en la red
    public string Jugador = "1";
    public string jugadorRED = "1";

    public string enemigo = "2";
    public string enemigoRED = "2";


    //cuando cambio los valores desde el inputField se 
    //tendrian que sincronizar las variables entre los jugadores y enemigos
    public void CambiarValor()
    {
        if(photonView.IsMine)
        {
            Jugador = PlayerInput.text;
            jugadorRED = Jugador;//este valor se tendria que compartir en la red
            //para ver en pantalla
            JugadorText.text = Jugador;
            enemigoREDText.text = enemigoRED;
        }
        if(!photonView.IsMine)
        {
            enemigo =  EnemigoInput.text;
            enemigoRED = enemigo;//este valor se tendria que compartir en la red
            //para ver en pantalla
            enemigoText.text = enemigo;
            jugadorREDText.text = jugadorRED;
        }
    }

   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("empezar");//empiezo despues de 3 segundos por las dudas
    }


    IEnumerator empezar()
    {
        yield return new WaitForSeconds(3);
       
        if(photonView.IsMine)//si es el jugador
        {
            informacion.text = "SOY JUGADOR";
            //Para datos
            jugadorRED = Jugador;

            //Para UI
            JugadorText.text = Jugador;
            enemigoREDText.text = enemigoRED;
        }

        if(!photonView.IsMine)//si es el enemigo
        {
            informacion.text = "SOY ENEMIGO";
            //Para datos
            enemigoRED = enemigo;

            //Para UI
            enemigoText.text = enemigo;
            jugadorREDText.text = jugadorRED;

        }
    }









    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
         if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        {

            stream.SendNext(Jugador);
            stream.SendNext(enemigo);
            stream.SendNext(jugadorRED);
            stream.SendNext(enemigoRED);
        }
        else //si esta escribiendo datos un avatar
        {
            Jugador = (string)stream.ReceiveNext();
            enemigo = (string)stream.ReceiveNext();
            jugadorRED = (string)stream.ReceiveNext();
            enemigoRED = (string)stream.ReceiveNext();
        }
    }

}
