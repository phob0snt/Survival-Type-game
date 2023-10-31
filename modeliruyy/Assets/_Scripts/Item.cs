using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [NonSerialized] public Sprite icon;
    [NonSerialized] public int id;
    [NonSerialized] public string itemName;
}
