using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject BulletP;
    public GameObject Player;

    private int Health = 3;
    private float LastShoot;

    private void Update()
    {
        if(Player == null)
        {
            return;  
        }

        Vector3 direction = Player.transform.position - transform.position;
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        float distance = (Player.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else 
        {
            direction = Vector2.left;
        }

        GameObject bullet = Instantiate(BulletP, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);

        Debug.Log("Shoot");
    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    

}
