using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public int selectAirplane;
    public GameObject destination; // 도착지점

    private GameObject airplane;
    private BombAim bombAim;


    private static Vector3 destinationPosition;
    public static Vector3 DestinationPosition
    {
        get { return destinationPosition; }
    }

    private bool spawnFlag;


    void Start()
    {
        if (selectAirplane == 1)
        {
            airplane = GameManager.GetGameManager.Airpplane1;
        }
        else if(selectAirplane == 2)
        {
            airplane = GameManager.GetGameManager.Airpplane1;
        }
        destinationPosition = destination.transform.position;
        bombAim = GameManager.GetGameManager.BombAim;
        spawnFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        AirplainSpawn();
    }

    private void AirplainSpawn()
    {
        if (!spawnFlag && Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bombAim.transform.position.z);
            destinationPosition = new Vector3(destination.transform.position.x, transform.position.y, transform.position.z);
            spawnFlag = true;
            //Vector3 initRotateVec = new Vector3(-90, 90, 0);
            airplane.transform.position = transform.position;
            //airplane.transform.rotation = Quaternion.Euler(initRotateVec);
            Instantiate(airplane);
        }
    }

}
