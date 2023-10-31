using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Item data", order = 51)]
public class ItemsData : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite icon;

    public int Id
    {
        get { return id; }
    }
    public string ItemName
    {
        get { return itemName; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
}
