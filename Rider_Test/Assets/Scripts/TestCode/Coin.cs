using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10; // ������ �ִ� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾����� Ȯ��
        {
            Score score = FindObjectOfType<Score>(); // Score ��ũ��Ʈ�� ã�Ƽ�
            if (score != null)
            {
                score.UpdatePoint(coinValue); // ������ ������Ű�� �Լ� ȣ��
            }

            Destroy(gameObject); // ���� �ı�
        }
    }
}
