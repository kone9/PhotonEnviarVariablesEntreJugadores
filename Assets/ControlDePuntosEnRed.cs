using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class ControlDePuntosEnRed : MonoBehaviourPunCallbacks//,IPunObservable
{
    public InputField VariableLocalInput;
    
    //referecia a los textos de la escena
    public Text VariableLocalText;
    public Text VariableRedText;

    //valores para modificar en la red
    public string tomarDatosRival = "0";

    //cuando cambio los valores desde el inputField se 
    //tendrian que sincronizar las variables entre los jugadores y enemigos
    public void CambiarValor()
    {
       string value = VariableLocalInput.text;
       VariableLocalText.text = value;
       photonView.RPC(nameof(CambiarValorEnRed), RpcTarget.OthersBuffered, value);
    }

    [PunRPC]
    void CambiarValorEnRed(string variable)
    {
        VariableRedText.text = variable;
        tomarDatosRival = variable;
    }

    
}
