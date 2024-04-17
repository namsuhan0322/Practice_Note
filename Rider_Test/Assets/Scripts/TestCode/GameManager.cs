using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameover_text;       // ���� ���� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ

    public static GameManager instance;

    bool isGamaover;

    void Start()
    {
        isGamaover = false;
    }

    void Update()
    {
        // ���� ������
        if (isGamaover)
        {
            // ���� ������ ���¿��� RŰ�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Dodge �� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void RetryGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGamaover = true;
        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameover_text.SetActive(true);
    }
}