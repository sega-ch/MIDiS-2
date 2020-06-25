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
            MouseDayn();
            dayn = true;
        }
        if (!Input.GetMouseButtonDown(0) && dayn != true)
        {
            MouseDayn();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseDayn();
            dayn = false;
        }

    }
    public void MouseDayn()
    {
        Joystick.transform.position = Input.mousePosition;
    }
}
