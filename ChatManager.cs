using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ChatManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI chatText;
    public TMP_InputField chatInput;

    private List<string> chatMessages = new List<string>();
    private int maxChatMessages = 10;

    private void Start()
    {
        chatInput.ActivateInputField();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !string.IsNullOrEmpty(chatInput.text))
        {
            SendMessage(chatInput.text);
            chatInput.text = "";
            chatInput.ActivateInputField();
        }
    }

    private void SendMessage(string message)
    {
        if (PhotonNetwork.IsConnected)
        {
            message = $"[{PhotonNetwork.LocalPlayer.NickName}]: {message}";
            photonView.RPC("ReceiveMessage", RpcTarget.All, message);
        }
    }

    [PunRPC]
    private void ReceiveMessage(string message)
    {
        chatMessages.Add(message);

        while (chatMessages.Count > maxChatMessages)
        {
            chatMessages.RemoveAt(0);
        }

        UpdateChatText();
    }

    private void UpdateChatText()
    {
        chatText.text = string.Join("\n", chatMessages.ToArray());
    }
}