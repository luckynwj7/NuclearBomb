using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    private Vector3 destinationPosition;
    private float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        destinationPosition = AirplaneSpawner.DestinationPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed * Time.deltaTime);
    }
}

