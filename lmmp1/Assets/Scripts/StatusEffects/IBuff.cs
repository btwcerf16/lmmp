using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuff
{
    void Apply(ActorStats stats,MonoBehaviour owner);
}
