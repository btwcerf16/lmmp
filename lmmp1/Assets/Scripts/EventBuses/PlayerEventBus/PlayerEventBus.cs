using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEventBus 
{ 
    public static Action<float> onPlayerHeal;
    public static Action<float> onPlayerDamaged;
    public static Action<float> onPlayerCast;
    public static Action<float> onPlayerStaminaChanged;
    public static Action onPlayerAttack;
}

