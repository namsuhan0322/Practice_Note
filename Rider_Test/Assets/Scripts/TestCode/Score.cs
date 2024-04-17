using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;                                              // Scene �̵� �ϱ� ���ؼ�

public class Score : MonoBehaviour
{
    public int Point = 0;                                                       // ����Ʈ ��� ����
    public float CheckTime = 0;                                                 // Ÿ�� Gen �ð�����
    public float GameTime;                                                      // ���� �ð� ����

    public Text pointUI;                                                        // Unity UI����
    public Text timeUI;                                                         // Unity UI����

    // ���� ���� �Լ� 
    public void UpdatePoint(int value)
    {
        Point += value; // ���� ����
        Update(); // UI ������Ʈ
    }

    void Update()
    {
        CheckTime += Time.deltaTime;                                            // �������� �����Ǿ�ð��� ����ϰ� �Ѵ�.
        GameTime -= Time.deltaTime;                                             // ������ �ð��� �����Ͽ� 30�� -> 0�ʷ� ���� �Ѵ�.

        CheckTime += Time.deltaTime;                                            // ������ ������ ���ؼ� �ð��� ����
        if (CheckTime >= 1.0f)                                                  // ���� 1�ʰ� ������ ���
        {
            Point += 1;                                                         // point = point + 1 ��� (1���� �����ش�.) 
            CheckTime = 0.0f;                                                   // 1�ʰ� ������� �ʱ�ȭ (0�� -> 1�� -> 0�� -> 1��)
        }

        if (GameTime <= 0)                                                      // 0�ʰ� �Ǹ�
        {
            PlayerPrefs.SetInt("Coin", Point);                                 // ����Ƽ���� �����ϴ� ���� �Լ�
            SceneManager.LoadScene("MainScene");                                // MainScene���� �̵��Ѵ�.
        }

        pointUI.text = "���� : " + Point.ToString();                            // UI ���� ǥ�� 
        timeUI.text = "���� �ð� : " + GameTime.ToString();               // UI ���� �ð� ǥ��
    }
}