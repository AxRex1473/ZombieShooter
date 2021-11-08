using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 Direction;

    public float Speed;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        rb2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.GetComponent<PlayerMove>();
        Enemy enemy = collision.GetComponent<Enemy>();

        if (player != null)
        {
            player.Hit();
        }
        if (enemy != null)
        {
            enemy.Hit();
        }
        DestroyBullet();
    }

   
}
