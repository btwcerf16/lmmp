using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerOnEnable : MonoBehaviour
{ 
    [SerializeField]private Player player;

    private void OnEnable()
    {
        if (player != null)
        {
            player.currentStats.IsStaned = true;
        }
        else
        {
            Debug.LogWarning("Не выставлен экземпляр игрока в " +gameObject.name);
        }
    }
    private void OnDisable()
    {
        if (player != null)
        {
            player.currentStats.IsStaned = false;
        }
        else
        {
            Debug.LogWarning("Не выставлен экземпляр игрока в " + gameObject .name);
        }
    }

}
