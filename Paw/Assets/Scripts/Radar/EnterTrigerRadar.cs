using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigerRadar : MonoBehaviour
{
    Joystic_touch joystic_Touch;
    private GameObject data;
    TreasureEditor treasureEditor;
    CatDisturb CatDisturb;
    Controller Controller;
    RadarBonus RadarBonus;

    void Start()
    {
        joystic_Touch = GameObject.Find("Dog").GetComponent<Joystic_touch>();
        data = GameObject.Find("Data");
        RadarBonus = GameObject.Find("Dog").GetComponent<RadarBonus>();
        treasureEditor = data.GetComponent<TreasureEditor>();
        Controller = data.GetComponent<Controller>();
        CatDisturb = GameObject.Find("CatDisturbCol").GetComponent<CatDisturb>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (treasureEditor.purse == false && treasureEditor.amulet == false && CatDisturb.catDisturb == false) 
        {
            if (other.gameObject.tag == "Klad")
            {
                if (RadarBonus.IsFounded(other))
                {
                    if (!Controller.SpeedChanged)
                    {
                        joystic_Touch.speedMove -= Controller.SpeedReduce;
                        Controller.SpeedChanged = true;
                    }

                    RadarBonus.ArrowsCounter++;
                    RadarBonus.SetRadarArrows();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Klad")
        {
            if (RadarBonus.IsFounded(other))
            {
                if (Controller.SpeedChanged)
                {
                    joystic_Touch.speedMove += Controller.SpeedReduce;
                    Controller.SpeedChanged = false;
                }

                RadarBonus.ArrowsCounter--;
                RadarBonus.SetRadarArrows();
            }
        }
    }
}