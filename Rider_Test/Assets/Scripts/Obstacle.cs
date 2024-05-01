using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D circleCollider2D;
    public float fallDistance = 5.5f; // 플레이어와 덫 사이의 거리 임계값
    bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        rb.gravityScale = 0f; // 게임 시작 시 중력은 꺼져 있음
        circleCollider2D.enabled = false; // 충돌 무시
    }

    void Update()
    {
        if (!isFalling)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
                if (distanceToPlayer <= fallDistance)
                {
                    // 플레이어와 거리가 일정 값 이하일 때 덫이 떨어짐
                    rb.gravityScale = 5f; // 중력을 켜서 덫을 떨어뜨림
                    circleCollider2D.enabled = true; // 충돌을 활성화
                    isFalling = true; // 덫이 떨어졌음을 표시
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (collision.tag == "Player")
        {
            //상대방 게임 오브젝트에서 Player_controller 컴포넌트 가져오기
            Move move = collision.GetComponent<Move>();

            //상대방으로부터 Player_controller 컴포넌트를 가져오는 데 성공했다면
            if (move != null)
            {
                //상대방 Player_controller 컴포넌트의 Die 메서드 실행
                move.Die();
            }
        }
    }
}