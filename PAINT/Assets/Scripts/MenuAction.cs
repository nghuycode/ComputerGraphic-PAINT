﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAction : MonoBehaviour
{
    void OnSelect(string command) 
    {
        Debug.Log("Shape menu said:" + command);
    }
}
