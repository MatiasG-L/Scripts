using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item/base")]
public class Item : ScriptableObject
{
    
    new public string name = "Default Item";
    public Sprite icon = null;
    public string itemDescription = "used for crafting";
    public MovementScript movement;
    [SerializeField]
    private GameObject Sword;
    [SerializeField]
    private bool isStraight = false;
    [SerializeField]
    private double slashSpeed = 1;
    [SerializeField]
    private bool jaber = false;
    [SerializeField]
    private GameObject superSlasher;
    [SerializeField]
    private double atkBuff = 1;

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
