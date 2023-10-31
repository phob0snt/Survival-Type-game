using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    GameObject ItemMenu;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        EventBus.OnInvOpened += FreezePlayer;
        EventBus.OnItemDropped += Drop;
    }
    private void OnDisable()
    {
        EventBus.OnInvOpened -= FreezePlayer;
        EventBus.OnItemDropped -= Drop;
    }

    public void FreezePlayer(CinemachineVirtualCamera cam, bool state)
    {
        CinemachinePOV POV = cam.GetCinemachineComponent<CinemachinePOV>();
        Image centDot = GameObject.Find("centDot").GetComponent<Image>();
        switch (state)
        {
            case true:
                POV.m_HorizontalAxis.m_MaxSpeed = 0;
                POV.m_VerticalAxis.m_MaxSpeed = 0;
                player.CanMove = false;
                centDot.enabled = false;
                break;
            case false:
                POV.m_HorizontalAxis.m_MaxSpeed = 300;
                POV.m_VerticalAxis.m_MaxSpeed = 300;
                player.CanMove = true;
                centDot.enabled = true;
                break;
        }
    }

    public void Drop(int index)
    {
        ItemMenu = GameObject.Find("Canvas").transform.GetChild(0).GetChild(1).gameObject;
        InventorySystem.Instance.RemoveItem(index);
        player.GetComponent<Player>().DropItem(index);
        ItemMenu.SetActive(false);
    }
}
