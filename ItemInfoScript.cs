using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemInfoScript : MonoBehaviour
{
    public Text itemName;
    public Text itemDescription;



    public void SetUp(string name, string description)
    {

        itemName.text = name;
        itemDescription.text = description;

    }
}
