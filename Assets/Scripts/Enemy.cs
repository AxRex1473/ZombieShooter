using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    SpriteRenderer spr;

    public GameObject BulletP;
    public GameObject Player;
    [SerializeField]
    int Health = 3;
    private float LastShoot;
    [SerializeField]
    float rayDistance;
    [SerializeField]
    Color rayColor;
    [SerializeField]
    LayerMask layer;
    Bullet currentBullet;
 


    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if(!Player)
        {
            return;  
        }

        //Vector3 direction = Player.transform.position - transform.position;
        /*if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }*/

        Debug.Log(FlipSpriteX);
        spr.flipX = FlipSpriteX;

        float distance = (Player.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        //Vector3 direction;

       /* if (transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else 
        {
            direction = Vector2.left;
        }*/

        GameObject bullet = Instantiate(BulletP, postion2D + BulletDirection * 0.1f, Quaternion.identity);
        currentBullet = bullet.GetComponent<Bullet>();
        currentBullet.SetDirection(BulletDirection);
        currentBullet.Actor = "Enemy";
        currentBullet = null;
        //Debug.Log("Shoot");
    }

    public void Hit()
    {
        
        Health = Health - 1;
        if (Health == 0)
        {
            Destroy(gameObject);
            Score.scoreValue += 1;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.right * rayDistance);
        Gizmos.DrawRay(transform.position, Vector2.left * rayDistance);
    }

    bool PlayerIsToTheLeft => Physics2D.Raycast(transform.position,  Vector2.left, rayDistance, layer);
    bool PlayerIsToTheRight => Physics2D.Raycast(transform.position,  Vector2.right, rayDistance, layer);
    bool FlipSpriteX => PlayerIsToTheLeft ? true : PlayerIsToTheRight ? false : spr.flipX;
    Vector2 BulletDirection => spr.flipX ? Vector2.left : Vector2.right;
    Vector2 postion2D => transform.position ;

}
