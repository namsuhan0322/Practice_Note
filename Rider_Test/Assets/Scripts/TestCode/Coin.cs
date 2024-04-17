using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10; // 코인이 주는 점수

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 충돌한 오브젝트가 플레이어인지 확인
        {
            Score score = FindObjectOfType<Score>(); // Score 스크립트를 찾아서
            if (score != null)
            {
                score.UpdatePoint(coinValue); // 점수를 증가시키는 함수 호출
            }

            Destroy(gameObject); // 코인 파괴
        }
    }
}
