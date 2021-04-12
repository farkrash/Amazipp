﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject otherGameObject;
    [SerializeField] private Color lowAlphaColor;
    [SerializeField] private Color highAlphaColor;

    private void OnTriggerStay(Collider other)
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
 
}