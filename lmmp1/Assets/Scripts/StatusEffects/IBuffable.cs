using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface IBuffable 
{
    void AddBuff(Buff buff);
    void RemoveBuff(Buff buff);
    Canvas BuffStack { get; set; }
}
