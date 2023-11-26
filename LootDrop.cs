using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public List<Item> Drops = new List<Item>();
    // Start is called before the first frame update
    public Item GetItemDrop()
    {
        int randomNumber = Random.Range(1, 101);
        List<Item> possibleItem = new List<Item>();
        foreach(Item item in Drops)
        {
            if(randomNumber <= item.DropChance)
            {
                possibleItem.Add(item);
            }
            
        }
        if(possibleItem.Count > 0)
        {
            Item dropped = possibleItem[Random.Range(0, possibleItem.Count)];
            Debug.Log("You got: " + dropped);
            return dropped;
        }
        Debug.Log("No Drop");
        return null;
        
    }
}
