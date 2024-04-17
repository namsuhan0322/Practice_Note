using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;                                              // Scene 이동 하기 위해서

public class Score : MonoBehaviour
{
    public int Point = 0;                                                       // 포인트 계산 변수
    public float CheckTime = 0;                                                 // 타겟 Gen 시간변수
    public float GameTime;                                                      // 게임 시간 설정

    public Text pointUI;                                                        // Unity UI설정
    public Text timeUI;                                                         // Unity UI설정

    // 점수 증가 함수 
    public void UpdatePoint(int value)
    {
        Point += value; // 점수 증가
        Update(); // UI 업데이트
    }

    void Update()
    {
        CheckTime += Time.deltaTime;                                            // 프레임이 누적되어시간을 계산하게 한다.
        GameTime -= Time.deltaTime;                                             // 프레임 시간을 제거하여 30초 -> 0초로 가게 한다.

        CheckTime += Time.deltaTime;                                            // 프레임 시작을 더해서 시간을 측정
        if (CheckTime >= 1.0f)                                                  // 만약 1초가 지났을 경우
        {
            Point += 1;                                                         // point = point + 1 축약 (1점씩 더해준다.) 
            CheckTime = 0.0f;                                                   // 1초가 지날경우 초기화 (0초 -> 1초 -> 0초 -> 1초)
        }

        if (GameTime <= 0)                                                      // 0초가 되면
        {
            PlayerPrefs.SetInt("Coin", Point);                                 // 유니티에서 제공하는 저장 함수
            SceneManager.LoadScene("MainScene");                                // MainScene으로 이동한다.
        }

        pointUI.text = "점수 : " + Point.ToString();                            // UI 점수 표시 
        timeUI.text = "남은 시간 : " + GameTime.ToString();               // UI 남은 시간 표시
    }
}