using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float maxSpeed = 10.0f;

    // 피격시 색깔 변경
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        Application.targetFrameRate = 60;

        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // 플레이어 이동 간단 로직
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.RetryGame();
    }

    /* public void OnCollisionEnter2D(Collision2D collision)
     {
         // 피격판정
         if (collision.gameObject.tag == "Enemy")
         { 
             Debug.Log("플레이어가 맞았습니다");
             OnDamaged(collision.transform.position);
         }
     }

    void OnDamaged(Vector2 targetPos)
    {
        // 데미지 입을때의 레이어 번호
        gameObject.layer = 8;

        // 피격시 색깔변화
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // 피격시 튕겨나가고 무적 로직
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        // 무적시간
        Invoke("OffDamaged", 2);
    }

    void OffDamaged()
    {
        // 무적 해제 로직
        gameObject.layer = 7;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }*/
}
