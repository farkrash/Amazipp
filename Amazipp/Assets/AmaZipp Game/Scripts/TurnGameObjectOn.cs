using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGameObjectOn : MonoBehaviour
{
    [SerializeField]private Transform metalChild;
    [SerializeField]private bool isOpen = true;
    [SerializeField] private Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        metalChild = transform.GetChild(0);
        metalChild.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isOpen)
            {
                animator.SetBool("Open", true);
                isOpen = true;
            }
            else
            {
                animator.SetBool("Open", false);
                isOpen = false;
            }
        }
    }
}
