using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    private Vector3 destinationPosition;
    private float speed = 40.0f;

    private GameObject bomb;
    private bool bombSpawnFlag = false;
    private float bombAimInterval = 20.0f; // 폭탄과 에임사이의 최소 거리. 이 이내에 있을 때 폭탄이 떨어짐
    // Start is called before the first frame update
    void Start()
    {
        destinationPosition = AirplaneSpawner.DestinationPosition;
        bomb = GameManager.GetGameManager.Bomb;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        DropBomb();
    }

    private void DropBomb()
    {
        float deltaBombAimInterval = Time.deltaTime * bombAimInterval;
        Debug.Log(bombAimInterval);
        if(
            transform.position.x - GameManager.GetGameManager.BombAimPosition.x < deltaBombAimInterval
            && transform.position.x - GameManager.GetGameManager.BombAimPosition.x > -deltaBombAimInterval
            && !bombSpawnFlag)
        {
            bomb.transform.position = new Vector3(GameManager.GetGameManager.BombAimPosition.x, transform.position.y - 3, GameManager.GetGameManager.BombAimPosition.z); // TODO: 폭탄 크기에 비례한 y축 좌표 수정 필요
            Instantiate(bomb);
            bombSpawnFlag = true;
        }
    }
}

