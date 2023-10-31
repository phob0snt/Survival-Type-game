using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveSlot : MonoBehaviour, IDropHandler
{
    public bool isEmpty = true;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Debug.Log(dropped);

        DraggableItem draggedItem = dropped.GetComponent<DraggableItem>();
        Debug.Log(draggedItem);
        draggedItem.parentAfterDrag = transform;
    }
}
