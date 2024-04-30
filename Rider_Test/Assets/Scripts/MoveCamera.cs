using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float speed;

    void LateUpdate()
    {
        // ī�޶� �÷��̾� ���󰡰� �ϴ� ����
        Vector3 desiredPosition = target.position + Vector3.up * 4; // �÷��̾��� ��ġ���� ���� 1��ŭ �̵�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
