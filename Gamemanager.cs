using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gamemanager : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomSpwanPos = Random.insideUnitSphere * 5f;
        randomSpwanPos.y = 0f;

        PhotonNetwork.Instantiate(playerPrefab.name, randomSpwanPos, Quaternion.identity);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}