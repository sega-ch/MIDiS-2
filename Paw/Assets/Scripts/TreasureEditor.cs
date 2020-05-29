﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureEditor : MonoBehaviour
{
    [Header("Первая стадия")]
    public int toStage1;
    [Space]
    public byte bone1;
    public byte goldenBone1;
    public byte purse1;
    public byte amulet1;

    [Header("Вторая стадия")]
    public int toStage2;
    [Space]
    public byte bone2;
    public byte goldenBone2;
    public byte purse2;
    public byte amulet2;

    [Header("Третья стадия")]
    public int toStage3;
    [Space]
    public byte bone3;
    public byte goldenBone3;
    public byte purse3;
    public byte amulet3;

    [Header("Четвертая стадия")]
    public int toStage4;
    [Space]
    public byte bone4;
    public byte goldenBone4;
    public byte purse4;
    public byte amulet4;
    [HideInInspector]
    public bool bone = false;
    [HideInInspector]
    public bool goldenBone = false;
    [HideInInspector]
    public bool purse = false;
    [HideInInspector]
    public bool amulet = false;

    public void Stages()
    {
        if(toStage1 <= Klad_Up.podnatoKladov && toStage2 > Klad_Up.podnatoKladov)
        {
            byte sc = Stage(bone1, goldenBone1, purse1, amulet1);
            if (sc == 1)
            {
                bone = true;
            }
            if (sc == 2)
            {
                goldenBone = true;
            }
            if (sc == 3)
            {
                purse = true;
            }
            if (sc == 4)
            {
                amulet = true;
            }
            return;
        }
        if (toStage2 <= Klad_Up.podnatoKladov && toStage3 > Klad_Up.podnatoKladov)
        {
            byte sc = Stage(bone2, goldenBone2, purse2, amulet2);
            if (sc == 1)
            {
                bone = true;
            }
            if (sc == 2)
            {
                goldenBone = true;
            }
            if (sc == 3)
            {
                purse = true;
            }
            if (sc == 4)
            {
                amulet = true;
            }
            return;
        }
        if (toStage3 <= Klad_Up.podnatoKladov && toStage4 > Klad_Up.podnatoKladov)
        {
            byte sc = Stage(bone3, goldenBone3, purse3, amulet3);
            if (sc == 1)
            {
                bone = true;
            }
            if (sc == 2)
            {
                goldenBone = true;
            }
            if (sc == 3)
            {
                purse = true;
            }
            if (sc == 4)
            {
                amulet = true;
            }
            return;
        }
        if (toStage4 <= Klad_Up.podnatoKladov && toStage3 < Klad_Up.podnatoKladov)
        {
            byte sc = Stage(bone4, goldenBone4, purse4, amulet4);
            if (sc == 1)
            {
                bone = true;
            }
            if (sc == 2)
            {
                goldenBone = true;
            }
            if (sc == 3)
            {
                purse = true;
            }
            if (sc == 4)
            {
                amulet = true;
            }
            return;
        }
    }
    public byte Stage(byte kosto4ka, byte zolotayaKosto4ka, byte koshelok, byte amylet)
    {
        int[] nums = new int[100];
        
        if (kosto4ka != 0)
        {
            for (int i = 0; i < kosto4ka; i++)
            {
                nums[i] = 1;
            }
        }
        if (zolotayaKosto4ka != 0)
        {
            for (int i = 0 + kosto4ka; i < zolotayaKosto4ka + kosto4ka; i++)
            {
                nums[i] = 2;
            }
        }
        if (koshelok != 0)
        {
            for (int i = 0 + kosto4ka + zolotayaKosto4ka; i < koshelok + zolotayaKosto4ka + kosto4ka; i++)
            {
                nums[i] = 3;
            }
        }
        if (amylet != 0)
        {
            for (int i = 0 + kosto4ka + zolotayaKosto4ka + koshelok; i < amylet + koshelok + zolotayaKosto4ka + kosto4ka; i++)
            {
                nums[i] = 4;
            }
        }
        
    M:
        var ss = Random.Range(0, 100);
        if (nums[ss] == 1)
        {
            return (1);
        }
        if (ss == 2)
        {
            return (2);
        }
        if (nums[ss] == 3)
        {
            return (3);
            
        }
        if (nums[ss] == 4)
        {
            return (4);
        }
        goto M;
    }
}
