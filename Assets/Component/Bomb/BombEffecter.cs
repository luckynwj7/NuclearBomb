using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffecter : MonoBehaviour
{
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        explosionEffect.transform.position = transform.position;
        Instantiate(explosionEffect);
        Destroy(gameObject); //TODO: 이펙트라 자동삭제되지만, 안전하게 삭제하는 방법이 필요함?
    }
}
