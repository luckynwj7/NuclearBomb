using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    private int speed = 20;

    // Start is called before the first frame update

    private MainCamera()
    {
        Debug.Log("메인 카메라 생성");
        GameManager.GetGameManager.MainCamera = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCameraUsingKey();
    }

    private void MoveCameraUsingKey()
    {
        

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            float keyHorizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {

            float keyVertical = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * speed * Time.smoothDeltaTime * keyVertical, Space.World);
        }
    }

}
