using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    private Vector2 moveVector;
    private PlayerInputActions plr;
    [SerializeField] new Camera camera;
    [SerializeField] CharacterController controller;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Transform attachPoint;
    [SerializeField] Transform backPack;
    private Vector3 velocity;
    [SerializeField] private bool isGrounded;
    private bool itemInHand = false;
    private GameObject inHand;
    private bool df = false;
    private GameObject interactableGO;
    public bool CanMove;
    private GameObject droppedGO;

    private void Awake()
    {
        CanMove = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        plr = new PlayerInputActions();
        plr.Player.Enable();
    }
    private void Update()
    {
        PlayerMovement();
        RayInteractor();
    }

    private void PlayerMovement()
    {
        isGrounded = GameObject.Find("groundCheck").GetComponent<GroundCheck>().isGrounded;
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (isGrounded && velocity.y < 0)
            velocity.y = -2;
        controller.Move(velocity * Time.deltaTime);
        if (CanMove)
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
                velocity.y = Mathf.Sqrt(gravity * -4);
            this.transform.eulerAngles = new Vector3(0, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
            moveVector = plr.Player.Move.ReadValue<Vector2>();
            Vector3 move = this.transform.right * moveVector.x + this.transform.forward * moveVector.y;
            controller.Move(move * Time.deltaTime * 10);
        }
    }


    private void RayInteractor()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100))
        {
            interactableGO = hit.collider.gameObject;
            if (Input.GetKeyDown(KeyCode.G) && !itemInHand && interactableGO.GetComponent<Interactable>() != null)
            {
                itemInHand = true;
                inHand = interactableGO;
            }
            else if (Input.GetKeyDown(KeyCode.E) && (interactableGO.GetComponent<Item>() != null))
            {
                TakeItem(interactableGO.GetComponent<Item>());
            }
        }
        if (itemInHand)
        {
            if (inHand.GetComponent<Interactable>().isGrabbable && !df)
            {
                inHand.transform.SetPositionAndRotation(attachPoint.transform.position, attachPoint.transform.rotation);
                inHand.transform.parent = attachPoint.transform;
                df = true;
            }
        }
        Debug.DrawRay(camera.transform.position, camera.transform.forward * hit.distance, Color.green);
    }

    private void TakeItem(Item item)
    {
        InventorySystem.Instance.AddItem(item);
        interactableGO.transform.position = backPack.position;
        interactableGO.transform.parent = backPack;
        interactableGO.SetActive(false);
    }

    public void DropItem(int index)
    {
        Debug.Log("Player" + index);
        droppedGO = backPack.transform.GetChild(index).gameObject;
        droppedGO.SetActive(true);
        droppedGO.transform.parent = null;
        Physics.Raycast(this.transform.position, -transform.up);
    }
}
