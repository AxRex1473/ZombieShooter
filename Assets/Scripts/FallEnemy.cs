using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEnemy : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
