using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabtale.TTPlugins;

public class InitialzeClik : MonoBehaviour
{
    private void Awake()
    {
        TTPCore.Setup();
    }
}
