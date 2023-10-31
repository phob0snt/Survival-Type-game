using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    public static Action<CinemachineVirtualCamera, bool> OnInvOpened;
    public static Action<int> OnItemDropped;
    public static Action<bool> OnGrounded;
}
