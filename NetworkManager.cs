using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Awake() // "Awkae"�� �ƴ϶� "Awake"���� �մϴ�.
    {
        // Photon ������ ����
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // ������ ������ ����Ǹ� "Room"�̶�� �̸��� ���� �����ϰų� �����մϴ�.
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
    }

    public override void OnJoinedRoom()
    {
        // �뿡 �������� �� ȣ��Ǵ� �ݹ� �޼���
        // ���⿡�� ���� ���� �Ǵ� �߰����� ������ ������ �� �ֽ��ϴ�.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
