using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipperLaneAlphaLow : MonoBehaviour
{
   public bool alphaIsLow = true;

   private void Awake()
   {
       alphaIsLow = true;
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         if (alphaIsLow)
         {
            alphaIsLow = false;
         }
         else
         {
            alphaIsLow = true;
         }
      }
   }
}
