using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
}
