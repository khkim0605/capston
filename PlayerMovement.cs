using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun, IPunObservable
{
    private CharacterController controller;
    private Vector3 moveDirection;
    public float moveSpeed = 5.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        // 로컬 플레이어일 경우에만 컨트롤을 활성화
        if (photonView.IsMine)
        {
            // 움직임을 로컬에서만 제어
            enabled = true;
        }
        else
        {
            // 다른 플레이어의 움직임을 동기화
            enabled = false;
        }
    }

    private void Update()
    {
        if (!photonView.IsMine) return; // 로컬 플레이어가 아닌 경우 움직임을 업데이트하지 않음

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        moveDirection.Normalize();

        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    // Photon 동기화를 위한 메서드
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 데이터를 스트림에 쓰기 (로컬 플레이어의 위치 및 회전 정보)
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // 스트림에서 데이터 읽기 (다른 플레이어의 위치 및 회전 정보)
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}