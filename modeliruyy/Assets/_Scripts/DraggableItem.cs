using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentWhileDragging;
    [HideInInspector] public Transform parentAfterDrag;
    public GameObject origin;
    public Image image;
    public bool inActiveSlots = false;
    public bool isDragging = false;

    private ActiveSlot activeSlot;
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        parentWhileDragging = transform.parent;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        image = this.gameObject.GetComponent<Image>();
        image.raycastTarget = false;
        Debug.Log("paa - " + parentWhileDragging);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && activeSlot == null)
        {
            transform.position = Input.mousePosition;
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        transform.SetParent(parentAfterDrag);
        try
        {
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<ActiveSlot>().isEmpty)
            {

            }
        }
        catch
        {
            this.origin.GetComponent<UIInteractionController>().isCloned = false;
            Destroy(this.gameObject);
        }
        image.raycastTarget = true;
        if (!inActiveSlots)
            inActiveSlots = true;
        //activeSlot = parentAfterDrag.GetComponent<ActiveSlot>();
        //if (activeSlot.isEmpty)
        //{
        //    activeSlot.isEmpty = false;
        //    Transform currentTransform = transform;
        //    transform.SetParent(parentAfterDrag);
        //    parentAfterDrag.GetChild(0).SetParent(currentTransform);
        //    this.inActiveSlots = true;
        //    image.raycastTarget = true;
        //    activeSlot = parentAfterDrag.GetComponent<ActiveSlot>();
        //}
        //else
        //{
        //    if (parentAfterDrag.childCount != 0)
        //    {
        //        parentAfterDrag.GetChild(0).GetComponent<DraggableItem>().origin.GetComponent<UIInteractionController>().isCloned = false;
        //        Destroy(parentAfterDrag.GetChild(0).gameObject);
        //    }

        //    transform.SetParent(parentAfterDrag);
        //    image.raycastTarget = true;
        //}
    }

}
