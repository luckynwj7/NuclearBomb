﻿using UnityEngine;
using System.Collections.Generic;

public class ZombieCharacterControl : MonoBehaviour
{
    private enum ControlMode
    {
        Tank,
        Direct
    }

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;

    private Animator m_animator;
    //[SerializeField] private Rigidbody m_rigidBody;
    private Rigidbody m_rigidBody;

    private ControlMode m_controlMode = ControlMode.Tank;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;

    private Vector3 m_currentDirection = Vector3.zero;

    private float forwardMovingAxis = 0.0f;
    private float turningAxis = 0.0f;

    private float minStandingValue = 45; // 해당 각도가 넘어가면 다시 원위치로 돌아옴

    void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        //if (!m_animator) { gameObject.GetComponent<Animator>(); }
        //if (!m_rigidBody) { gameObject.GetComponent<Rigidbody>(); }

        
        InvokeRepeating("RandomMoveForward", 0.0f, Random.Range(0, 4));
        //InvokeRepeating("RandomTurning", 0.0f, 6.0f); // 2초뒤 LaunchProjectile함수 호출
    }

    private void Start()
    {
        
    }

    void Update()
    {
        //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        switch (m_controlMode)
        {
            case ControlMode.Direct:
                DirectUpdate();
                break;

            case ControlMode.Tank:
                TankUpdate();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == null)
        {
            //TODO:
        }
    }

    private void TankUpdate()
    {

        turningAxis = Random.Range(-1.0f, 1.0f);
        m_currentV = Mathf.Lerp(m_currentV, forwardMovingAxis, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, turningAxis, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

        m_animator.SetFloat("MoveSpeed", m_currentV);
        Standing();
    }

    private void DirectUpdate()
    {
       
    }

    private void RandomMoveForward()
    {
        forwardMovingAxis = Random.Range(0.0f, 1.0f);
        if (forwardMovingAxis < 0.5f)
        {
            forwardMovingAxis = 0.0f;
        }
        else
        {
            forwardMovingAxis = 1.0f;
        }
    }
    private void RandomTurning()
    {
        forwardMovingAxis = 0.0f;
        turningAxis = Random.Range(-1.0f, 1.0f);
    }

    private void Standing()
    {
        // 넘어질 때 일어서는 변수
        if(transform.eulerAngles.x > minStandingValue || transform.eulerAngles.z > minStandingValue)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0) * Time.deltaTime);
                
        }
    }


}
