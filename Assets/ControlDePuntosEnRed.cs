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
       string value = VariableLocalInput.text;//Obtengo el texto intresado luego es usado en mi mismo en el parametro del otro
       VariableLocalText.text = value;//cambia al jugador local
       //El tema de "nameof(CambiarValorEnRed)" es para obtener el nombre de la función, se podria escribir solo string, pero cuando el código crece cuesta buscar que hace cada cosa, entonces de esa forma podes ver donde se usa cada función.
       photonView.RPC(nameof(CambiarValorEnRed), RpcTarget.OthersBuffered, value);//cambia al otro jugador MUY IMPORTANTE USAR EL PÁRAMETRO EN LA FUNCIÓN
    
    }

    [PunRPC]
    void CambiarValorEnRed(string variable)//para ejecutar en el otro jugador, usa variables locales, pero se ejecuta en el otro que tambien usa las mismas variables
    {
        VariableRedText.text = variable;//CAMBIA EL texto del otro jugador
    }

    
}
