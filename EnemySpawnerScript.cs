using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public List<GameObject> Drops = new List<GameObject>();
    
    public float timerA = 0;
    public int EnemyCount = 4;
    public float Cooldown = 10;
    public float Health = 250;
    public double range = 10;
    private bool initialSpawn = false;
    public int dropCount = 1;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
        


        if (Health <= 0)
        {
            for (int i = 0; i < dropCount; i++)
            {
                Inventory.instance.AddItem(Instantiate(GetComponent<LootDrop>().GetItemDrop()));
            }
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, MovementScript.instance.transform.position) <= range)
        {
            if (!initialSpawn)
            {
                initialSpawn = true;
                SpawnEnemies();
                
            }

            timerA += Time.deltaTime;
            if (timerA >= Cooldown)
            {
                    SpawnEnemies();       
                timerA = 0;
            }
        }
    }
    public void SpawnEnemies()
    {
        
            for (int i = 0; i < EnemyCount; i++)
            {

                Instantiate(Drops[Random.Range(0, Drops.Count + 1)], transform.position + new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0), transform.rotation);
            }
        
    }
}
