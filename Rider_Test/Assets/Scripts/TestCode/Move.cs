using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float maxSpeed = 10.0f;

    // �ǰݽ� ���� ����
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        Application.targetFrameRate = 60;

        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // �÷��̾� �̵� ���� ����
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
         // �ǰ�����
         if (collision.gameObject.tag == "Enemy")
         { 
             Debug.Log("�÷��̾ �¾ҽ��ϴ�");
             OnDamaged(collision.transform.position);
         }
     }

    void OnDamaged(Vector2 targetPos)
    {
        // ������ �������� ���̾� ��ȣ
        gameObject.layer = 8;

        // �ǰݽ� ����ȭ
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // �ǰݽ� ƨ�ܳ����� ���� ����
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        // �����ð�
        Invoke("OffDamaged", 2);
    }

    void OffDamaged()
    {
        // ���� ���� ����
        gameObject.layer = 7;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }*/
}
