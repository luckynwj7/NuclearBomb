using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BombAim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mapMainPlain;

    private MainCamera mainCamera;
    private Vector3 mainCameraPosition;
    private float mainCameraDistance;

    //도달할 수 있는 가장자리
    private float plainMaxTop;
    private float plainMaxBottom;
    private float plainMaxLeft;
    private float plainMaxRight;

    private int speed = 10;
    private float maxDistance = 100; // 카메라와 에임의 최대 거리를 지정해 줌

    private BombAim()
    {
        GameManager.GetGameManager.BombAim = this;
    }
    void Start()
    {
        mainCamera = GameManager.GetGameManager.MainCamera;
        SetMaxSize();
    }

    private void SetMaxSize()
    {
        //Vector3 mapMainPlainSize = mapMainPlain.GetComponent<Renderer>().bounds.size; // 맵의 사이즈
        //Vector3 mapMainPlainPosition = mapMainPlain.GetComponent<Renderer>().bounds.center; // 맵의 중앙위치

        Vector3 mapMainPlainSize = mapMainPlain.GetComponent<Renderer>().bounds.size; // 맵의 사이즈
        Vector3 mapMainPlainPosition = mapMainPlain.transform.position; // 맵의 중앙위치

        Vector3 thisObjectVec = gameObject.GetComponent<Renderer>().bounds.size;
        float thisRadius = thisObjectVec.x / 3.0f;
        // 에임의 반지름을 구함

        plainMaxTop = mapMainPlainPosition.z + (mapMainPlainSize.z / 2.0f) - thisRadius;
        plainMaxBottom = mapMainPlainPosition.z - (mapMainPlainSize.z / 2.0f) + thisRadius;
        plainMaxRight = mapMainPlainPosition.x + (mapMainPlainSize.x / 2.0f) - thisRadius;
        plainMaxLeft = mapMainPlainPosition.x - (mapMainPlainSize.x / 2.0f) + thisRadius;

    }

    // Update is called once per frame
    void Update()
    {
        MoveAimUsingKey();
        SaveBombPosition();
    }

    private void MoveAimUsingKey()
    {
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && !IsArriveMaxSizeHorizontal())
        {
            float keyHorizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
            MoveMainCameraDistance();
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && !IsArriveMaxSizeVertical())
        {
            float keyHorizontal = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
            MoveMainCameraDistance();
        }
    }

    private bool IsArriveMaxSizeHorizontal()
    {
        if (transform.position.x > plainMaxRight)
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.smoothDeltaTime);
            return true;
        }
        else if (transform.position.x < plainMaxLeft)
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.smoothDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsArriveMaxSizeVertical()
    {
        // 90도 회전된 상태이기 때문에 y축을 translate함
        if (transform.position.z > plainMaxTop)
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.smoothDeltaTime);
            return true;
        }
        else if (transform.position.z < plainMaxBottom)
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.smoothDeltaTime);
            return true;
        }
        else
        {
            return false;
        }

    }

    private void MoveMainCameraDistance()
    {
        mainCameraPosition = mainCamera.transform.position;
        mainCameraDistance = Vector3.Distance(transform.position, mainCameraPosition);

        if (mainCameraDistance > maxDistance)
        {
            Vector3 targetVec = new Vector3(transform.position.x, mainCameraPosition.y, transform.position.z); // y축은 그대로 유지시킴
            float cameraMoveSpeed = (float)speed * (mainCameraDistance - maxDistance); // 떨어진 거리만큼 더 빠르게 카메라 복귀
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetVec, cameraMoveSpeed * Time.deltaTime);
        }
    }

    private void SaveBombPosition()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameManager.GetGameManager.BombAimPosition = transform.position;
        }
    }

}
