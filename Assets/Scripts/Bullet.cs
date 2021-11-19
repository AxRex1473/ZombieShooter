using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 Direction;
    string actor;

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

    public string Actor{get => actor; set => actor = value;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && actor == "Enemy")
        {
            PlayerMove player = collision.GetComponent<PlayerMove>();
            player.Hit();
        }
        if(collision.CompareTag("Enemy") && actor == "Player")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Hit();
        }
        if(collision.tag != actor && collision.tag != "bullet")
        {
            DestroyBullet();
        }
    }

}
