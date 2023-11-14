using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private bool inventoryOpen = false;
    public bool InventoryOpen => inventoryOpen;
    public GameObject InventoryParent;
    public GameObject InventoryTab;
    public GameObject CraftingTab;
    public GameObject inventorySlotPrefab;
    public GameObject CraftingSlotPrefab;
    public Transform InventoryItemTransform;

    public Transform craftingItemTransform;

    private List<ItemScript> itemSlotList = new List<ItemScript>();
    // Start is called before the first frame update
    private void Start()
    {
        Inventory.instance.onItemChange += UpdateInventoryUI;
        UpdateInventoryUI();
        SetUpCrafttingRecipies();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (InventoryOpen)
            {
                //close
                CloseInventory();
            }
            else
            {
                //open
                OpenInventory();
            }
        }


    }

    private void SetUpCrafttingRecipies()
    {
        List<Item> craftingRecipies = GameManager.instance.carftingRecipes;
        foreach (Item recipe in craftingRecipies) 
        {
            GameObject GO = Instantiate(CraftingSlotPrefab, craftingItemTransform);
            ItemScript slot = GO.GetComponent<ItemScript>();
            slot.AddItem(recipe);
        }
    }

    private void UpdateInventoryUI()
    {
        int currentItemCount = Inventory.instance.inventoryItemList.Count;

        if (currentItemCount > itemSlotList.Count)
        {
            // add more item slots
            AddItemSlots(currentItemCount);
        }
        for (int i = 0; i < itemSlotList.Count; ++i)
        {
            if(i < currentItemCount)
            {
                //update the current item in slot
                itemSlotList[i].AddItem(Inventory.instance.inventoryItemList[i]);
            }
            else
            {
                itemSlotList[i].DestroySlot();
                itemSlotList.RemoveAt(i);
            }
        }
    }

    private void AddItemSlots(int currentItemCount)
    {
        int amount = currentItemCount - itemSlotList.Count;

        for (int i = 0 ; i < amount; ++i)
        {
            GameObject GO = Instantiate(inventorySlotPrefab, InventoryItemTransform);
            ItemScript newSlot = GO.GetComponent<ItemScript>();
            itemSlotList.Add(newSlot);
        }
    }

    private void OpenInventory()
    {
        inventoryOpen = true;
        InventoryParent.SetActive(true);
    }

    private void CloseInventory()
    {
        inventoryOpen = false;
        InventoryParent.SetActive(false);
    }

    public void OnCraftingTabClicked()
    {
        InventoryTab.SetActive(false);
        CraftingTab.SetActive(true);

    }

    public void OnInventoryTabClicked()
    {

        InventoryTab.SetActive(true);
        CraftingTab.SetActive(false);


    }


}
