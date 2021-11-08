using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        if(Player != null)
        {
            Vector3 position = transform.position;
            position.x = Player.transform.position.x;
            transform.position = position;
        }       
    }
}
