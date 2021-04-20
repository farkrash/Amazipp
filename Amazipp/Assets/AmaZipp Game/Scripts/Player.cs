using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject otherGameObject;
    [SerializeField] private Color lowAlphaColor;
    [SerializeField] private Color highAlphaColor;
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ZipperLane")
        {
            
            otherGameObject = other.gameObject;
            var zipperAlphaScript = otherGameObject.GetComponent<ZipperLaneAlphaLow>();

            zipperAlphaScript.timesEntered++;
            
            if (zipperAlphaScript.alphaIsLow)
            {
                zipperAlphaScript.alphaIsLow = false;
            }
            else
            {
                zipperAlphaScript.alphaIsLow = true;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ZipperLane")
        {
            otherGameObject = other.gameObject;
            var zipperAlphaScript = otherGameObject.GetComponent<ZipperLaneAlphaLow>();
            
            if (zipperAlphaScript.isCornerTile && zipperAlphaScript.timesEntered == zipperAlphaScript.requiredTimeForChange)
            {
                if (zipperAlphaScript.alphaIsLow)
                {
                    zipperAlphaScript.alphaIsLow = false;
                }
                else
                {
                    zipperAlphaScript.alphaIsLow = true;
                }
            }
            
        }
    }

    /*
   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.tag == "ZipperLane" && other.gameObject.GetComponent<Renderer>() != null)
       {
           otherGameObject = other.gameObject;
           var zipperAlphaScript = otherGameObject.GetComponent<ZipperLaneAlphaLow>();
           var renderer = other.GetComponent<Renderer>();
           Material material = renderer.material;
           Color color = material.color;
           
               if (zipperAlphaScript.alphaIsLow)
               {
                   material.color = highAlphaColor;
               }
               else if (!zipperAlphaScript.alphaIsLow)
               {
                   material.color = lowAlphaColor;
               }
       }
   }
   */
    
}
