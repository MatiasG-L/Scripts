using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region singleton 

    public static Inventory instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    #endregion


    public delegate void OnItemChange();
    public OnItemChange onItemChange = delegate { };

    public List<Item> inventoryItemList = new List<Item>();
    public List<Item> hotbarItemList = new List<Item>();
    public HotBarController hotBarController;
    // Start is called before the first frame update
    private void Start()
    {
        hotBarController = GameObject.FindGameObjectWithTag("HorBar").GetComponent<HotBarController>();
    }
    public void SwitchItemInventory(Item item)
    {
        foreach(Item i in inventoryItemList)
        {
            if (i == item)
            {
                if(hotbarItemList.Count >= hotBarController.HotbarSlotSize)
                {
                    Debug.Log("no more slots avalible :(");
                }
                else
                {
                    hotbarItemList.Add(item);
                    inventoryItemList.Remove(item);
                    onItemChange.Invoke();
                }
                return;
            }
        }

        foreach (Item i in hotbarItemList)
        {
            if (i == item)
            {
                hotbarItemList.Remove(item);
                inventoryItemList.Add(item);
                onItemChange.Invoke();
                return;
            }
        }
    }


    public void AddItem(Item item)
    {
        inventoryItemList.Add(item);
        onItemChange.Invoke();
    }

    public void RemoveItem(Item item)
    {   
        if (inventoryItemList.Contains(item))
        {
            inventoryItemList.Remove(item);
        }
        else if (hotbarItemList.Contains(item))
        {
            hotbarItemList .Remove(item);
        }

        onItemChange.Invoke();
            
    }

    public bool ContainsItem(Item item, int amount)
    {
        int itemCounter = 0;
        foreach(Item i in inventoryItemList)
        {
            if (i == item)
            {
                itemCounter++;
            }
        }
        if (itemCounter>= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void RemoveItems(Item item, int amount)
    {
       for(int i = 0; i < amount; ++i)
        {
            RemoveItem(item);
        }
    }

}


