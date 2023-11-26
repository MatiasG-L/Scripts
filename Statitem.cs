using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "StatItem", menuName = "Item/StatItem")]


public class Statitem : Item
{
    public StatItemType itemType;
    public float amount;
    public override void Use()
    {
        
        GameManager.instance.OnStatItemUsed(itemType, amount);
        Inventory.instance.RemoveItem(this);
    }

}

public enum StatItemType 
{
    Heal,
    HealthIncrease,
    SpeedBuff1,
    SpeedBuff2,
    StrengthBuff
}
