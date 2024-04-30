using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
