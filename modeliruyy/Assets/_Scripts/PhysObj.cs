using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysObj
{
    float Durability { get; set; }
    void OnCollisionEnter(Collision collision);
}
