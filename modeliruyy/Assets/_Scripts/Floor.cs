using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] float CustDur = 0.1f;
    public float Durability { get; set; } = 0.1f;

    private void Awake()
    {
        Durability = CustDur;
    }
}
