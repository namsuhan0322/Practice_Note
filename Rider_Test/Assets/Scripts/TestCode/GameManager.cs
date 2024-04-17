using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameover_text;       // 게임 오버 시 활성화할 텍스트 게임 오브젝트

    public static GameManager instance;

    bool isGamaover;

    void Start()
    {
        isGamaover = false;
    }

    void Update()
    {
        // 게임 오버면
        if (isGamaover)
        {
            // 게임 오버인 상태에서 R키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Dodge 씬 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void RetryGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGamaover = true;
        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameover_text.SetActive(true);
    }
}