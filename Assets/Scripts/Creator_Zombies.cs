using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator_Zombies : MonoBehaviour
{
    [SerializeField]
    public GameObject Enemy;
    public GameObject Spawn;
    public float TimeCreation;
    //public float RangeCreation;

    void Start()
    {
        
    }
    
    private void Update() 
    {
        TimeCreation = TimeCreation += Time.deltaTime;
        
        if(TimeCreation > 3)
        {
            Creando();           
            TimeCreation = 0; 
        } 


    }

    public void Creando()
    {
        //SpawnPosition = this.transform.position + Random.onUnitSphere * RangeCreation;
        
        Instantiate(Enemy, transform.position = new Vector3(Enemy.transform.position.x + Random.Range(-8f, 0f), 
        Enemy.transform.position.y, 0), transform.rotation);
        //this.Enemy.transform.position = new Vector3(this.Enemy.transform.position.x + Random.Range(-5f, 5f), this.Enemy.transform.position.y, 0);
        //Vector3 Enemy = new Vector3(this.Enemy.transform.position.x + Random.Range(-5f, 5f), this.Enemy.transform.position.y, 0);
        //GameObject Enemys = Instantiate (Enemy, SpawnPosition, Quaternion.identity);   
        
    }
}