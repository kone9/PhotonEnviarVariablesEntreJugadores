using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;

public class UIInformacion : MonoBehaviourPunCallbacks,IPunObservable
{
	public Text infoTxt;
	public int playerNum;

	private void Start() 
	{
		StartCoroutine("SetPlayerOrEnemy");
		// SetPlayerOrEnemy();
	}



	IEnumerator SetPlayerOrEnemy()
	{
		yield return new WaitForSeconds(3);
		if (photonView.IsMine)
			infoTxt.text = "SOY JUGADOR";
		if (!photonView.IsMine)
			infoTxt.text = "SOY ENEMIGO";
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }

    // public override void OnConnected()
    // {
    //     if (photonView.IsMine)
    // 		infoTxt.text = "SOY JUGADOR";
    // 	if (!photonView.IsMine)
    // 		infoTxt.text = "SOY ENEMIGO";
    // }
}
