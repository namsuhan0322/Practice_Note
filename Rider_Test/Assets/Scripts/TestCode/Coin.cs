using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Point = 10; // 코인이 주는 점수

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 충돌한 오브젝트가 플레이어인지 확인
        {
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.UpdatePoint(Point); // GameManager의 UpdatePoint 메서드를 호출하여 점수 증가
            }

            Destroy(gameObject); // 코인 파괴
        }
    }
}
