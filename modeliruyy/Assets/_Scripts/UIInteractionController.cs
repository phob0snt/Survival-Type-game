using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInteractionController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isCloned = false;
    GameObject cloneRef;
    GameObject tempDraggableItem;
    public void OnPointerEnter(PointerEventData mouseData)
    {
        if (mouseData.pointerEnter.CompareTag("UIButton"))
        {
            if (!isCloned)
            {
                GameObject tempDraggableItem = GetComponent<InventoryItem>().Dragging();
                cloneRef = tempDraggableItem;
                tempDraggableItem.transform.SetParent(transform.root);
                tempDraggableItem.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
                tempDraggableItem.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                tempDraggableItem.AddComponent<DraggableItem>();
                tempDraggableItem.GetComponent<DraggableItem>().origin = gameObject;
                isCloned = true;
            }
            GameObject ItemMenu = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
            ItemMenu.SetActive(true);
            ItemMenu.transform.position = new Vector2(mouseData.pointerEnter.transform.position.x + 120, mouseData.pointerEnter.transform.position.y - 30);
        }
    }

    public void OnPointerExit(PointerEventData mouseData)
    {
        GameObject ItemMenu = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        ItemMenu.SetActive(false);
        if (GetComponent<DraggableItem>() != null)
        {
            if (!(GetComponent<DraggableItem>().isDragging) && !(GetComponent<DraggableItem>().inActiveSlots))
            {
                GetComponent<DraggableItem>().origin.GetComponent<UIInteractionController>().isCloned = false;
                Destroy(gameObject);
            }
            
        }
            
        //Destroy(cloneRef);
        
    }
}
