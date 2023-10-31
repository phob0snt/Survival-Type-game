using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> InvMainSlots;
    public List<GameObject> InvActiveSlots;
    [SerializeField] private Transform currItemBox;
    private float currItemBoxXPos;
    private readonly List<KeyCode> keys = new (6) { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6 };

    private List<Item> InvItems;
    [SerializeField] private CinemachineVirtualCamera cam;
    private bool invOpened;

    private void Start()
    {
        currItemBoxXPos = currItemBox.transform.position.x;
    }

    private void Update()
    {
        InventoryDisplay();
        InventoryUpdateItems();
    }


    private void InventoryDisplay()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !invOpened)
        {
            invOpened = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            EventBus.OnInvOpened(cam, true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && invOpened)
        {
            invOpened = false;
            this.transform.GetChild(0).gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            EventBus.OnInvOpened(cam, false);
        }
    }

    private void InventoryUpdateItems()
    {
        InvItems = InventorySystem.Instance.InvItems;
        //for (int i = 0; i < 24; i++)
        //{
        //    Image currItem = InvMainSlots[i].GetComponent<Image>();
        //        try
        //        {
        //            if (InvItems[i] != null)
        //            {
        //                currItem.sprite = InvItems[i].icon;
        //                currItem.color = Color.white;
        //            }
        //            else
        //            {
        //                currItem.sprite = null;
        //                currItem.color = Color.clear;
        //            }
        //        }
        //        catch
        //        {
        //            currItem.sprite = null;
        //            currItem.color = Color.clear;
        //        }
        //}
    }
    private void OnGUI()
    {
        if (!invOpened && Input.anyKey)
        {
            if (keys.Contains(Event.current.keyCode))
            {
                foreach (KeyCode key in keys)
                {
                    if (Event.current.keyCode == key)
                        ChangeCurrSlot(keys.IndexOf(key));
                }
            }
        }
    }

    private void ChangeCurrSlot(int SlotIndex)
    {
        currItemBox.position = new Vector2(currItemBoxXPos + (80 * SlotIndex), currItemBox.position.y);
        InventorySystem.Instance.CurrentSlot = SlotIndex;
    }
}
