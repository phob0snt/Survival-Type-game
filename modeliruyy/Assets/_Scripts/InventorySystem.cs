using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    [SerializeField] private GameObject itemPF;
    public List<Item> InvItems = new(24);
    public int CurrentSlot;

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < 24; i++)
        {
            InvItems.Add(null);
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < 24; i++)
        {
            if (InvItems[i] == null)
            {
                InvItems[i] = item;
                GameObject newItem = Instantiate(itemPF);
                newItem.GetComponent<InventoryItem>().Initialize(item);
                newItem.transform.SetParent(GameObject.Find("Canvas").GetComponent<InventoryUI>().InvMainSlots[i].transform);
                break;
            }
        }
    }

    public IEnumerator UpdateSlots()
    {
        List<GameObject> InvMainSlots = GameObject.Find("Canvas").GetComponent<InventoryUI>().InvMainSlots;
        for (int i = 0; i < 24; i++)
        {
            yield return new WaitForSeconds(0);
            if (InvMainSlots[i].transform.childCount == 1 && i == 0)
                continue;
            if (InvMainSlots[i].transform.childCount == 1)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (j < 0)
                        break;
                    if (InvMainSlots[j].transform.childCount == 1 || j == 0)
                    {
                        InvMainSlots[i].transform.GetChild(0).SetParent(InvMainSlots[j + 1].transform);
                        break;
                    }
                }
            }
            //catch
            //{
            //    GameObject.Find("Canvas").GetComponent<InventoryUI>().InvMainSlots[i + 1].transform.GetChild(0).SetParent(GameObject.Find("Canvas").GetComponent<InventoryUI>().InvMainSlots[i].transform);
            //}
        }
    }
    public void RemoveItem(int index)
    {
        InvItems.RemoveAt(index);
        InvItems.Add(null);
        Destroy(GameObject.Find("Canvas").GetComponent<InventoryUI>().InvMainSlots[index].transform.GetChild(0).gameObject);
        StartCoroutine(UpdateSlots());
        Debug.Log("InvRemovedAtIndex" + index);
    }

}
