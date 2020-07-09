using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AimSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    //public bool enableSpawn = false;
    public GameObject aimObject; //Prefab을 받을 public 변수 입니다.
    public GameObject mapMainPlain; // 바닥

    /*
    void SpawnEnemy()
    {
        float randomX = Random.Range(-0.5f, 0.5f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(0,1,0), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
        }
    }*/

    void Start()
    {
        
        //InvokeRepeating("SpawnEnemy", 3, 1); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
        Vector3 InitPositionVec = new Vector3(0, 1, 0);
        Vector3 InitRotateVec = new Vector3(90, 0, 0);
        aimObject.transform.position = InitPositionVec;
        aimObject.transform.rotation = Quaternion.Euler(InitRotateVec);

        Instantiate(aimObject);
        //Debug.Log(aimObject.GetComponent<Renderer>().isVisible);

        //Instantiate(aimObject,InitVec, Quaternion.Euler(90,0,0));
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ㅇㅇ" + aimObject.transform.position);
    }
}
