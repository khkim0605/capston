using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Awake() // "Awkae"가 아니라 "Awake"여야 합니다.
    {
        // Photon 서버에 연결
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // 마스터 서버에 연결되면 "Room"이라는 이름의 룸을 생성하거나 입장합니다.
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
    }

    public override void OnJoinedRoom()
    {
        // 룸에 입장했을 때 호출되는 콜백 메서드
        // 여기에서 게임 시작 또는 추가적인 설정을 수행할 수 있습니다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
