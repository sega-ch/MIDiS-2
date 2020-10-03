using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedactorKlada : MonoBehaviour
{
    [Header("Первая стадия")]
    public static int Do_stadii_1;
    [Space]
    
    public static byte Kosto4ka_1;
    [Range(0, 100)]
    public static byte ZolotayaKosto4ka_1;
    [Range(0, 100)]
    public static byte Koshelok_1;
    [Range(0, 100)]
    public static byte Amylet_1;
    [Header("Вторая стадия")]
    public static int Do_stadii_2;
    [Space]
    [Range(0, 100)]
    public static byte Kosto4ka_2;
    [Range(0, 100)]
    public static byte ZolotayaKosto4ka_2;
    [Range(0, 100)]
    public static byte Koshelok_2;
    [Range(0, 100)]
    public static byte Amylet_2;
    [Header("Третья стадия")]
    public static int Do_stadii_3;
    [Space]
    [Range(0, 100)]
    public static byte Kosto4ka_3;
    [Range(0, 100)]
    public static byte ZolotayaKosto4ka_3;
    [Range(0, 100)]
    public static byte Koshelok_3;
    [Range(0, 100)]
    public static byte Amylet_3;
    [Header("Четветая стадия")]
    public static int Do_stadii_4;
    [Space]
    [Range(0, 100)]
    public static byte Kosto4ka_4;
    [Range(0, 100)]
    public static byte ZolotayaKosto4ka_4;
    [Range(0, 100)]
    public static byte Koshelok_4;
    [Range(0, 100)]
    public static byte Amylet_4;

    public static bool kosto4ka = false;
    public static bool zolotayaKosto4ka = false;
    public static bool koshelok = false;
    public static bool amylet = false;
    public byte Stadiya(byte kosto4ka, byte zolotayaKosto4ka, byte koshelok, byte amylet)
    {
    M:
        if (Random.Range(1, 100) <= kosto4ka)
        {
            return (1);
        }
        var s1 = 100 - kosto4ka;
        if (Random.Range(1, s1) <= zolotayaKosto4ka)
        {
            return (2);
        }
        var s2 = s1 - zolotayaKosto4ka;
        if (Random.Range(1, s2) <= koshelok)
        {
            return (3);
        }
        var s3 = s2 - koshelok;
        if (Random.Range(1, s3) <= amylet)
        {
            return (4);
        }
        goto M;


    }
}
