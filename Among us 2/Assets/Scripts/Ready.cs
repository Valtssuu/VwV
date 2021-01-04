using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour
{
    // Start is called before the first frame update
    private bool pressedReady = false;
    private GameObject gameManager;
    private PhotonView photonViewVar;

    void Start()
    {
        photonViewVar = PhotonView.Get(this);
        gameManager = GameObject.FindWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && pressedReady == false)
        {
            pressedReady = true;
            photonViewVar.RPC("ReadyCount", RpcTarget.All);
        }
    }

    [PunRPC]
    void ReadyCount()
    {
        gameManager.GetComponent<PhotonManager>().readyCount += 1;
    }
}
