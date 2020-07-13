using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerInflator : MonoBehaviour
{
    private GameManager gameManager;

    // 이미 생성된 객체에 대해 적용
    // 없음

    // 생성되지 않은 객체에 대해 적용
    public GameObject airplane1;
    public GameObject airplane2;

    // Start is called before the first frame update
    GameManagerInflator()
    {
        gameManager = GameManager.GetGameManager;
    }
    void Awake()
    {
        gameManager.Airpplane1 = airplane1;
        gameManager.Airpplane2 = airplane2;
        Debug.Log("게임매니저 후삽입 완료");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
