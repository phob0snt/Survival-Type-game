using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public GameObject item;

    private void Awake()
    {
        if (transform.childCount != 0)
            item = transform.GetChild(0).gameObject;
    }
}
