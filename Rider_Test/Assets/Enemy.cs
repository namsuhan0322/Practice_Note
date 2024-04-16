using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
