using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    #endregion

    // Start is called before the first frame update
    public List<Item> ItemList = new List<Item>();
    public List<Item> carftingRecipes = new List<Item>();
    public Transform canvas;
    public GameObject ItemInfoPrefab;
    private GameObject currentItemInfo = null;
    public Transform mainCanvas;
    public Transform hotbarTransform;
    public MovementScript movement;
    public GameObject SlashObj;
    public GameObject JabObj;

    private void Start()
    {
        Inventory.instance.AddItem(GameManager.instance.ItemList[1]);
       
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Item newItem = ItemList[Random.Range(0, ItemList.Count)];

            Inventory.instance.AddItem(Instantiate(newItem));
        }
    
        if (movement.equip == 1)
        {
            
        }
        else 
        {
           
        }
     
    }

    public void OnStatItemUsed(StatItemType itemType, int amount)
    {
        Debug.Log("Consuming: " + itemType + "Add Amount: " + amount);
    }

    public void DisplayItemInfo(string itemName, string itemDescription, Vector2 buttonPos)
    {
        if(currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }
        buttonPos.x += -155;
        buttonPos.y += 95;
        currentItemInfo = Instantiate(ItemInfoPrefab, buttonPos, Quaternion.identity, canvas);
        currentItemInfo.GetComponent<ItemInfoScript>().SetUp(itemName, itemDescription);
    }
    public void DestroyItemInfo()
    {
        if(currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }
    }

    public void SlashFX(Vector3 pos, Quaternion rotat, Transform paret, bool isJab)
    {
        if (isJab)
        {
            Instantiate(JabObj, pos, rotat, paret);
        }
        else
        {
            Instantiate(SlashObj, pos, rotat, paret);
        }
        
     
    }
}
