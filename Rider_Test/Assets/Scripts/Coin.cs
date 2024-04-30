using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Point = 10; // ������ �ִ� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾����� Ȯ��
        {
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.UpdatePoint(Point); // GameManager�� UpdatePoint �޼��带 ȣ���Ͽ� ���� ����
            }

            Destroy(gameObject); // ���� �ı�
        }
    }
}
