using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameover_text; // ���� ���� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ       

    bool isGameover;

    public int Point = 0; // ����Ʈ ��� ����
    public float CheckTime = 0; // Ÿ�� Gen �ð�����
    public float GameTime; // ���� �ð� ����

    public Text pointUI; // Unity UI����
    public Text timeUI; // Unity UI����
    public Text bestTimeUI; // Unity UI����

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
            CheckTime += Time.deltaTime; // Ÿ�̸� ������Ʈ
            GameTime -= Time.deltaTime; // ���� �ð� ������Ʈ

            pointUI.text = "���� : " + Point.ToString();
            timeUI.text = "���� �ð� : " + FormatTime(GameTime);

            if (CheckTime >= 1.0f) // 1�ʸ��� ����Ǵ� �ڵ�
            {
                Point++; // ���� ����
                CheckTime = 0.0f; // Ÿ�̸� �ʱ�ȭ
            }
        }

        // ���� ������
        if (isGameover && Input.GetKeyDown(KeyCode.R))
        {
            // Dodge �� �ε�
            SceneManager.LoadScene("SampleScene");

            // ���Ӹ���� �ٽ� Ȱ��ȭ
            Time.timeScale = 1;
        }
    }

    public void UpdatePoint(int value)
    {
        Point += value; // ���� ����
    }

    public void RetryGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;

        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameover_text.SetActive(true);

        if (Point > best_score) // �߰�: ���� ������ �ְ� �������� ������ ����
        {
            best_score = Point;
            PlayerPrefs.SetInt("Best_score", best_score); // �߰�: �ְ� ������ ����
        }

        // �ְ� ���� ǥ��
        bestTimeUI.text = "Best Score: " + best_score.ToString();
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
