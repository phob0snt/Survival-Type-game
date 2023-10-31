using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public ItemsData item;
    [Range(1, 999)]
    public int amount;
}
[CreateAssetMenu]
public class CraftRecipe : ScriptableObject
{
    public List<ItemAmount> materials;
    public List<ItemAmount> result;
}
