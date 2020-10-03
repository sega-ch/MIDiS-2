using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseObj : MonoBehaviour
{
    public GameObject Joystick;
    bool dayn = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dayn = true;
        }
        if (!Input.GetMouseButtonDown(0) && dayn != true)
        {
            Joystick.transform.position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            dayn = false;
        }
    }
}
