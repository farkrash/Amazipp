using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGameObjectOn : MonoBehaviour
{
    [SerializeField] private Transform metalChild;
    [SerializeField] private bool isOpen = true;
    [SerializeField] private Animator animator;
    [SerializeField] private int timesEnterd = 0;
    [SerializeField] private int requiredTimesEnterd = 2;
    [SerializeField] private bool needsTimeEnetrd;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        metalChild = transform.GetChild(0);
        metalChild.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) // used to be exit
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timesEnterd++;
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
    private void OnTriggerExit(Collider other)
    {
        if (needsTimeEnetrd)
        {
            if (timesEnterd == requiredTimesEnterd)
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

    }
}
