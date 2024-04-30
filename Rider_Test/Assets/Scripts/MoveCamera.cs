using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float speed;

    void LateUpdate()
    {
        // 카메라가 플레이어 따라가게 하는 로직
        Vector3 desiredPosition = target.position + Vector3.up * 4; // 플레이어의 위치에서 위로 1만큼 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
