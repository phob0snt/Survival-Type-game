using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Resource : Item
{
    [SerializeField] private ItemsData resourceData;

    private void OnEnable()
    {
        id = resourceData.Id;
        itemName = resourceData.ItemName;
        icon = resourceData.Icon;
    }
}
