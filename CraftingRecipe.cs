using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CraftingRecipe/baseRecipe")]
public class CraftingRecipe : Item
{
    public Item result;
    public Ingredient[] ingredients;

    public bool CanCraft()
    {
        foreach(Ingredient ingredient in ingredients)
        {
            bool containsCurrentIngredient = Inventory.instance.ContainsItem(ingredient.item, ingredient.amount);
            if (!containsCurrentIngredient)
            {
                return false;
            }
        }

        return true; 
       
    }
    private void RemoveIngredientsFromInventory()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            Inventory.instance.RemoveItems(ingredient.item, ingredient.amount);
        }
    }
    public override void Use()
    {
        if (CanCraft())
        {
            RemoveIngredientsFromInventory();

            Inventory.instance.AddItem(result);
            Debug.Log("Crafted a " + result.name);
        }
        else
        {
            Debug.Log("cant craft " + result.name);
        }
    }

    public override string GetItemDescription()
    {
        string itemIngredients = " ";
        foreach (Ingredient ingredient in ingredients)
        {
            itemIngredients += "- " + ingredient.amount + " " + ingredient.item.name + "\n";
        }
        return itemIngredients;
    }





    [System.Serializable]
    public class Ingredient 
    {
        public Item item;
        public int amount;
    }

}
