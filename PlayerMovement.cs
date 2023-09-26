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

        // ���� �÷��̾��� ��쿡�� ��Ʈ���� Ȱ��ȭ
        if (photonView.IsMine)
        {
            // �������� ���ÿ����� ����
            enabled = true;
        }
        else
        {
            // �ٸ� �÷��̾��� �������� ����ȭ
            enabled = false;
        }
    }

    private void Update()
    {
        if (!photonView.IsMine) return; // ���� �÷��̾ �ƴ� ��� �������� ������Ʈ���� ����

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        moveDirection.Normalize();

        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    // Photon ����ȭ�� ���� �޼���
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // �����͸� ��Ʈ���� ���� (���� �÷��̾��� ��ġ �� ȸ�� ����)
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // ��Ʈ������ ������ �б� (�ٸ� �÷��̾��� ��ġ �� ȸ�� ����)
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}