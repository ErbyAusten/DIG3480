﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator2 : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(-15, -30, -45) * Time.deltaTime);
    }
}