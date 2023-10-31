using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public void Initialize(Item item)
    {
        this.GetComponent<Image>().sprite = item.icon;
    }

    public GameObject Dragging()
    {
        Debug.Log("ads");
        GameObject copy = Instantiate(this.gameObject);
        copy.GetComponent<UIInteractionController>().isCloned = true;
        return copy;
    }
}
