using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuff
{
    IStats ApplyBuff(IStats character);
}
