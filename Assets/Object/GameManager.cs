using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager gameManager;
    private GameManager()
    {
        Debug.Log("게임매니저 생성");
        
    }
    public static GameManager GetGameManager
    {
        get
        {
            // 싱글톤 패턴
            if (gameManager is null)
            {
                gameManager = new GameManager();
            }
            return gameManager;
        }
    }

    // 자기자신 객체를 대입할 때는 생성자에
    // 다른 객체를 대입할 때는 Start에 적용시켜서 사용할 것

    //무대위에 이미 올려져 있는 객체에 대해 적용
    private MainCamera mainCamera;
    public MainCamera MainCamera
    {
        get { return mainCamera; }
        set { mainCamera = value; }
    }
    private BombAim bombAim;
    public BombAim BombAim
    {
        get { return bombAim; }
        set { bombAim = value; }
    }

    // 무대위에 없는 객체에 대해 적용
    private GameObject airplane1;
    public GameObject Airpplane1
    {
        get { return airplane1; }
        set { airplane1 = value; }
    }
    private GameObject airplane2;
    public GameObject Airpplane2
    {
        get { return airplane2; }
        set { airplane2 = value; }
    }

    private void GameManagerInit()
    {

    }


    

}
