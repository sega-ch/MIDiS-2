using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarBonus : MonoBehaviour
{
    [HideInInspector]
    public bool poska1 = false;//тригеры от активаций полоски из скрипта "EnterTrigerRadar"
    [HideInInspector]
    public bool poska2 = false;
    [HideInInspector]
    public bool poska3 = false;
    [HideInInspector]
    public bool poska4 = false;

    public GameObject polrad1;
    public GameObject polrad2;
    public GameObject polrad3;
    public GameObject polrad4;//объект полоски

    public GameObject shadowRad1;//тень полоски
    public GameObject shadowRad2;
    public GameObject shadowRad3;
    public GameObject shadowRad4;

    public GameObject rad4;//коллайдер 4 радара

    public bool bonusOn;

    public void BonusRadarOn()
    {
        rad4.SetActive(true);
        bonusOn = true;
    }
    public void BonusRadarOff()
    {
        rad4.SetActive(false);
        bonusOn = false;
    }
    public void ChangePoskiRadara()
    {
        if (poska1 == true)
        { 
            if (bonusOn)
            {
                polrad4.SetActive(true);
            }
            else
            polrad3.SetActive(true);
            Debug.Log("c1");
        }
        if (poska2 == true)
        {
            if (bonusOn)
            {
                polrad3.SetActive(true);
            }
            else
            polrad2.SetActive(true);
            Debug.Log("c2");
        }
        if (poska3 == true)
        {
            if (bonusOn)
            {
                polrad2.SetActive(true);
            }
            else
            polrad1.SetActive(true);
            Debug.Log("c3");
        }
        if (poska4)
        {
            polrad1.SetActive(true);
        }

        if (poska1 && poska2 && poska3 && poska4)
        {
            ShadowRadOn();
            Debug.Log("shn");
        }
        if (!poska1 && !poska2 && !poska3 && !poska4)
        {
            ShadowRadOff();
            Debug.Log("shf");
        }

        if (!poska1)
        {
            if (bonusOn)
            {
                polrad4.SetActive(false);
            }
            else
                polrad3.SetActive(false);
        }
        if (!poska2)
        {
            if (bonusOn)
            {
                polrad3.SetActive(false);
            }
            else
                polrad2.SetActive(false);
        }
        if (!poska3)
        {
            if (bonusOn)
            {
                polrad2.SetActive(false);
            }
            else
                polrad1.SetActive(false);
        }
        if (!poska4)
        {
            polrad1.SetActive(false);
        }

    }
    public void ShadowRadOn()
    {
        if (bonusOn)
        {
            shadowRad1.SetActive(true);
            shadowRad2.SetActive(true);
            shadowRad3.SetActive(true);
            shadowRad4.SetActive(true);
        }
        else
        {
        shadowRad1.SetActive(true);
        shadowRad2.SetActive(true);
        shadowRad3.SetActive(true);
        }
    }
    public void ShadowRadOff()
    {
        shadowRad1.SetActive(false);
        shadowRad2.SetActive(false);
        shadowRad3.SetActive(false);
        shadowRad4.SetActive(false);
    }
}
