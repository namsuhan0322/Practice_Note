using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameover_text; // 게임 오버 시 활성화할 텍스트 게임 오브젝트       

    bool isGameover;

    public int Point = 0; // 포인트 계산 변수
    public float CheckTime = 0; // 타겟 Gen 시간변수
    public float GameTime; // 게임 시간 설정

    public Text pointUI; // Unity UI설정
    public Text timeUI; // Unity UI설정
    public Text bestTimeUI; // Unity UI설정

    private int best_score;

    void Start()
    {
        isGameover = false;
        best_score = PlayerPrefs.GetInt("Best_score", 0);
    }

    void Update()
    {
        if (!isGameover)
        {
            CheckTime += Time.deltaTime; // 타이머 업데이트
            GameTime -= Time.deltaTime; // 게임 시간 업데이트

            pointUI.text = "점수 : " + Point.ToString();
            timeUI.text = "남은 시간 : " + FormatTime(GameTime);

            if (CheckTime >= 1.0f) // 1초마다 실행되는 코드
            {
                Point++; // 점수 증가
                CheckTime = 0.0f; // 타이머 초기화
            }
        }

        // 게임 오버면
        if (isGameover && Input.GetKeyDown(KeyCode.R))
        {
            // Dodge 씬 로드
            SceneManager.LoadScene("SampleScene");

            // 게임멈춘거 다시 활성화
            Time.timeScale = 1;
        }
    }

    public void UpdatePoint(int value)
    {
        Point += value; // 점수 증가
    }

    public void RetryGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;

        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameover_text.SetActive(true);

        if (Point > best_score) // 추가: 현재 점수가 최고 점수보다 높으면 갱신
        {
            best_score = Point;
            PlayerPrefs.SetInt("Best_score", best_score); // 추가: 최고 점수를 저장
        }

        // 최고 점수 표시
        bestTimeUI.text = "Best Score: " + best_score.ToString();
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
