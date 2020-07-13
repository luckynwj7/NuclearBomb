using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public int spawnCount;
    public GameObject zombieObject;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int counting = 0; counting < spawnCount; counting++)
        {
            Vector3 initPositionVec = new Vector3(0, 1, 0);
            Vector3 initRotateVec = new Vector3(0, 0, 0);
            zombieObject.transform.position = initPositionVec;
            zombieObject.transform.rotation = Quaternion.Euler(initRotateVec);
            Instantiate(zombieObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
