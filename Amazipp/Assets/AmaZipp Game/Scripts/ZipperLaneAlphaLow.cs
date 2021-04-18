using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipperLaneAlphaLow : MonoBehaviour
{
   public bool alphaIsLow = false;
   [SerializeField] private Color lowAlphaColor;
   [SerializeField] private Color highAlphaColor;
   private Renderer myRenderer;

   private void Awake()
   {
       alphaIsLow = false;
       myRenderer = GetComponent<Renderer>();
   }

   private void Update()
   {
      ChangeAlpha();
   }
   
   private void ChangeAlpha()
   {
      if (alphaIsLow)
      {
         Material material = myRenderer.material;
         Color color = material.color;
         material.color = lowAlphaColor;
      }
      else
      {
         Material material = myRenderer.material;
         Color color = material.color;
         material.color = highAlphaColor;
      }
   }

   /*
   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         if (alphaIsLow)
         {
            Material material = myRenderer.material;
            Color color = material.color;
            material.color = lowAlphaColor;
         }
         else
         {
            Material material = myRenderer.material;
            Color color = material.color;
            material.color = highAlphaColor;
         }
      }
   }
   */

   
   
}
