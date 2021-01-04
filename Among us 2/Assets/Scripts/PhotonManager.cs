using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    private int playerCount;
    public int readyCount;
    private bool loading = false;
    private PhotonView photonViewVar;


    // Start is called before the first frame update
    void Start()
    {
        photonViewVar = PhotonView.Get(this);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;

        if (SceneManager.GetActiveScene().name != "Lobby")
        {
            PhotonNetwork.Instantiate("Steve", new Vector2(Random.Range(-8f, 11f), transform.position.y), Quaternion.identity);            
        }
    }

    private void Update()
    {

        if (readyCount >= playerCount && readyCount > 0 && SceneManager.GetActiveScene().name == "Lobby" && loading == false)
        {
            loading = true;
            PhotonNetwork.LoadLevel("TestLevel");
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions {MaxPlayers=5}, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        if(SceneManager.GetActiveScene().name == "Lobby")
        {
            photonViewVar.RPC("PlayerCount", RpcTarget.All);
            PhotonNetwork.Instantiate("Steve", new Vector2(Random.Range(-8f, 11f), transform.position.y), Quaternion.identity);
        }
    }

    [PunRPC]
    void PlayerCount()
    {
        playerCount += 1;
    }
}
