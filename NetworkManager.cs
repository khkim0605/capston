using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
 
public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Screen.SetResolution(960, 600, false); // PC ���� �� �ػ� ����
        //PhotonNetwork.ConnectUsingSettings(); // ���� ���ἳ��
    }
 
    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions(); // ��ɼǼ���
        options.MaxPlayers = 5; // �ִ��ο� ����
        PhotonNetwork.JoinOrCreateRoom("Room1", options, null); // ���� ������ �����ϰ� 
                                                                // ���ٸ� ���� ����� �����մϴ�.
    }
 
}