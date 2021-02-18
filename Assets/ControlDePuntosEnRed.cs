using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class ControlDePuntosEnRed : MonoBehaviourPunCallbacks,IPunObservable
{

    public InputField VariableLocalInput;
    public Text informacion;

    //referecia a los textos de la escena
    public Text VariableLocalText;
    public Text VariableRedText;



    //valores para modificar en la red
    public string VariableLocal = "1";

   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("empezarTodo");//empiezo despues de 3 segundos por las dudas
        // photonView.RPC("empezarConRed",RpcTarget.All,photonView.IsMine);
        StartCoroutine("actualizarTextosCadaCiertoTiempoEnRed");//actualiza los textos en pantalla
    }


    //cuando cambio los valores desde el inputField se 
    //tendrian que sincronizar las variables entre los jugadores y enemigos
    public void CambiarValor()
    {
        photonView.RPC("CambiarValorEnRed",RpcTarget.All,photonView.IsMine);
    }

    [PunRPC]
    void CambiarValorEnRed(bool soyJugador)
    {
        if(soyJugador)
        {
            VariableLocal = VariableLocalInput.text;
            //para ver en pantalla
            VariableLocalText.text = VariableLocal;
            
        }
        if(!soyJugador)
        {
            VariableRedText.text = VariableLocal;
        }
    }


    //PARA ACTUALIZAR LOS TEXTOS CADA 1 SEGUNDO
    ////////////////////////////////////////////////////////
    IEnumerator actualizarTextosCadaCiertoTiempoEnRed()
    {
        
        yield return new WaitForSeconds(4f);
        while(true)
        {
            photonView.RPC("actualizarTextos",RpcTarget.All,photonView.IsMine);
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    [PunRPC]
    public void actualizarTextos(bool soyJugador)
    {
        if(soyJugador)
        {
            VariableLocalText.text = VariableLocal;
        }
        if(!soyJugador)
        {
            VariableRedText.text = VariableLocal;
        }
    }
    ///////////////////////////////////////////////////////

    
    //PARA INCIAR Y VER MERNSAJE SI SOY JUGADOR O ENEMIGO
    //////////////////////////////////////////////////////
    IEnumerator empezarTodo()
    {
        yield return new WaitForSeconds(5);
        photonView.RPC("empezarConRed",RpcTarget.All,photonView.IsMine);
    }

    [PunRPC]
    void empezarConRed(bool SoyJugador)
    {
        if(SoyJugador)//si es el jugador
        {
            informacion.text = "SOY JUGADOR";
        }

        if(!SoyJugador)//si es el enemigo
        {
            informacion.text = "SOY ENEMIGO";
        }
    }
    /////////////////////////////////////////////////////


    //mandar la variable entre todos los jugadores,utilizo 1 sola variable
    //la idea es poder saber cuando es mía o cuando es del enemigo
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
         if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        {
            stream.SendNext(VariableLocal);
        }
        else //si esta escribiendo datos un avatar
        {
            VariableLocal = (string)stream.ReceiveNext();
        }
    }

}
