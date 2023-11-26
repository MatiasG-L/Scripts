using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item/base")]
public class Item : ScriptableObject
{
    
    new public string name = "Default Item";
    public Sprite icon = null;
    public int DropChance;
    public string itemDescription = "used for crafting";
    public MovementScript movement;
    public GameObject Sword;
    public bool isStraight = false;
    public double slashSpeed = 1;
    public bool jaber = false;
    public GameObject superSlasher;
    public double atkBuff = 1;

    public virtual void Use()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();

        Debug.Log("Using " + name);

            if (movement.equip == 1)
            {

                movement.equip = 0;
                movement.unEquip();
                return;
            }
            movement.equip = 1;
            movement.Equip(Sword, isStraight, slashSpeed, jaber, superSlasher, atkBuff);
              
            
        
    
    }

    public virtual string GetItemDescription()
    {
        return itemDescription;
    }

}
