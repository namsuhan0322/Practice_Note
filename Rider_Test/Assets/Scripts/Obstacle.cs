using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D circleCollider2D;
    public float fallDistance = 5.5f; // �÷��̾�� �� ������ �Ÿ� �Ӱ谪
    bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        rb.gravityScale = 0f; // ���� ���� �� �߷��� ���� ����
        circleCollider2D.enabled = false; // �浹 ����
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
                    // �÷��̾�� �Ÿ��� ���� �� ������ �� ���� ������
                    rb.gravityScale = 5f; // �߷��� �Ѽ� ���� ����߸�
                    circleCollider2D.enabled = true; // �浹�� Ȱ��ȭ
                    isFalling = true; // ���� ���������� ǥ��
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (collision.tag == "Player")
        {
            //���� ���� ������Ʈ���� Player_controller ������Ʈ ��������
            Move move = collision.GetComponent<Move>();

            //�������κ��� Player_controller ������Ʈ�� �������� �� �����ߴٸ�
            if (move != null)
            {
                //���� Player_controller ������Ʈ�� Die �޼��� ����
                move.Die();
            }
        }
    }
}