using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class ManejadorRed : MonoBehaviourPunCallbacks
{
    public Text informacion;
    public static ManejadorRed instanciaRed;//para isntanciar la red PHOTON y conectarme al servidor

    private void Awake()
    {
        //Esto evita que se destruya  el game object que maneja la red
        if(instanciaRed == null)
        {
            instanciaRed = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }    
    }


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//Crea 2 eventos on "OnConnectedToMaster" y "OnJoinedLobby"
    }

    //Cuando se conecta al servidor maestro
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        print("Felicidades estoy conectado al servidor maestro");
        informacion.text = "Felicidades estoy conectado \n al servidor maestro";
    }

    //al unirse al servidor crea un cuarto
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Cuarta", new RoomOptions{MaxPlayers = 4}, TypedLobby.Default );
    }

    public override void OnCreatedRoom()
    {
        print("cuarto creado");
        informacion.text = "cuarto creado";
    }

    
    public override void OnJoinedRoom()//cuando nos unamos al cuerto podemos instanciar jugadores o hacer cualquier cosa con los GameObjects
    {
        print("Este jugador se unido al cuerto");
        informacion.text = "Este jugador se unido al cuerto";

        // if(photonView.IsMine)
        // {
        //     informacion.text = "Soy Jugador";
        // }
        // if(!photonView.IsMine)
        // {
        //     informacion.text = "Soy enemigo";
        // }

        //desde aqui puedo isntanciar cosas al iniciar el nivel usar la carpeta resources de photon
        // PhotonNetwork.Instantiate("Personaje",posicion,Quaternion.identity,0);
    }


}
