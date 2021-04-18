using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGameObjectOn : MonoBehaviour
{
    [SerializeField]private Transform metalChild;
    [SerializeField]private bool childIsActive = true;

    private void Awake()
    {
        metalChild = transform.GetChild(0);
        metalChild.gameObject.SetActive(true);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!childIsActive)
            {
                metalChild.gameObject.SetActive(true);
                childIsActive = true;
            }
            else
            {
                metalChild.gameObject.SetActive(false);
                childIsActive = false;
            }
        }
    }
}
