using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class Telescope : MonoBehaviour
{
    [SerializeField] private GameObject skillTree;
    [SerializeField] private bool canOpen;
    [SerializeField] private bool isOpen;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            isOpen = !isOpen;
        }
        switch (isOpen) 
        {
            case false:
            {
                skillTree.SetActive(false);
                break;
            }
            case true:
            {
                skillTree.SetActive(true);
                break;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpen = false;
            canOpen = false;
        }
    }
}
