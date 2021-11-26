using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float h;
    private bool Grounded;
    private Animator anim;
    private float LastShoot;
    [SerializeField]
    int Health = 10;

    public GameObject BulletPrefab;
    public float Jumpforce;
    public float Speed;
    Bullet currentBullet;
        
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento en Horizontal del player
        h = Input.GetAxisRaw("Horizontal");

        // Seg�n el lado al que se mueva el player tambien su posici�n
        if (h < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (h > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        // Llamamos al animaator para hacer la animaci�n de correr
        anim.SetBool("Running", h != 0.0f);

        // Dibujamos una linea para que sepa donde esta colisionando despu�s del salto 
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        // Llamamos a la funci�n del salto 
        if(Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.F) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    // Salto
    private void Jump()
    {
        rb2D.AddForce(Vector2.up * Jumpforce * Speed);
    }

    // Disparo 
    private void Shoot()
    {
        // Direction era un Vector2, pero como no se puede mantener sumando con position lo convertimos a Vector3
        Vector3 direction;

        if(transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        GameObject bullet =  Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        currentBullet = bullet.GetComponent<Bullet>();
        currentBullet.SetDirection(direction);
        currentBullet.Actor = "Player";
        currentBullet = null;
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(h, rb2D.velocity.y);
    }

    public void Hit()
    {
        
        Health = Health - 1;
        if(Health == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
            Score.scoreValue = 0;
        }
    }
}
