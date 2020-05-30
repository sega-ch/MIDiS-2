using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //GameObject rad1, rad2, rad3, rad4;
    public bool SpeedChanged = false;
    public float SpeedReduce;
    public int TreasureAmmount;

    void Update() {
        if(TreasureAmmount < 0) TreasureAmmount = 0;
    }
}
