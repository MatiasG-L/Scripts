using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{

    public Image icon;
    private Item item;
    public bool isBeingDraged = false;
    public Item Item => item;


    private void Start()
    {
      
    }
    public void AddItem(Item newItem)
    {

        item = newItem;
        icon.sprite = newItem.icon;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
    }
    public void UseItem()
    {
        if (item == null || isBeingDraged == true) return;
        Debug.Log("Trying To Switch");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Trying To Switch");
            Inventory.instance.SwitchItemInventory(item);
        }
        else
        {
            item.Use();
        }
            
        
    }
    public void DestroySlot()
    {
        Destroy(gameObject);
    }
    public void OnRemoveButtonClicked()
    {
        if (item != null)
        {
            Inventory.instance.RemoveItem(item);
        }
    }
    public void OnCursorEnter()
    {
        if (item == null || isBeingDraged == true) return;
        GameManager.instance.DisplayItemInfo(item.name, item.GetItemDescription(), transform.position);
    }
    public void OnCursorExit()
    {
        if (item == null) return;
        GameManager.instance.DestroyItemInfo();
    }
}
