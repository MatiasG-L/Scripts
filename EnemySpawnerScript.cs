using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public List<GameObject> Drops = new List<GameObject>();
    public float timerA = 0;
    public int EnemyCount = 4;
    public float Cooldown = 10;
    public int MaxEnemyCount = 5;
    public float Health = 250;
    public double range = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
        {
        Destroy(gameObject);
        }
        
        timerA += Time.deltaTime;
        if (timerA >= Cooldown)
        {
            SpawnEnemies();
            timerA = 0;
        }
    }
    public void SpawnEnemies()
    {
        for(int i  = 0; i < EnemyCount; i++)
        {
            Instantiate(Drops[Random.Range(1,Drops.Count + 1)], transform.position + new Vector3(Random.Range(-4,4), Random.Range(-4, 4), 0), transform.rotation);
        }
    }
}
