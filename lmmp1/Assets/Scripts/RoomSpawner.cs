using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField]private Tilemap RoomVariant;
    [SerializeField]private GameObject RoomParent;
    private void Start()
    {
        Instantiate(RoomVariant, RoomParent.transform);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
