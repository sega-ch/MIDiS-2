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
    public int ktoTyt;
    void Start()
    {
        joystic_Touch = GameObject.Find("Dog").GetComponent<Joystic_touch>();
        data = GameObject.Find("Data");
        RadarBonus = data.GetComponent<RadarBonus>();
        treasureEditor = data.GetComponent<TreasureEditor>();
        Controller = data.GetComponent<Controller>();
        CatDisturb = GameObject.Find("CatDisturbCol").GetComponent<CatDisturb>();
    }

    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (treasureEditor.purse == false && treasureEditor.amulet == false && CatDisturb.catDistrub == false)//если не подобран кошель или амулет или кот мешает
        {
            if (other.gameObject.tag == "Klad")//проверяем что это клад по тегу
            {
               
                if (!Controller.SpeedChanged)//меняем скорость
                {
                    joystic_Touch.speedMove -= Controller.SpeedReduce;
                    Controller.SpeedChanged = true;
                }
                switch (ktoTyt)//смотрим какое изначальное значение заданно и меняем состояние флажка
                {
                    case 1:
                        RadarBonus.poska1 = true;
                        Debug.Log("e1" + RadarBonus.poska1);
                        return;
                    case 2:
                        RadarBonus.poska2 = true;
                        Debug.Log("e2" + RadarBonus.poska2);
                        return;
                    case 3:
                        RadarBonus.poska3 = true;
                        Debug.Log("e3" + RadarBonus.poska3);
                        return;
                    case 4:
                        RadarBonus.poska4 = true;
                        Debug.Log("e4" + RadarBonus.poska4);
                        return;
                }
                RadarBonus.ChangePoskiRadara();
            }
        }
    }
    private void OnTriggerExit(Collider other)//если клад выходит из зоны действия радара
    {
        if (other.gameObject.tag == "Klad")//проверяем что это клад по тегу
        {
            if (Controller.SpeedChanged)//меняем скорость
            {
                joystic_Touch.speedMove += Controller.SpeedReduce;
                Controller.SpeedChanged = false;
            }
            RadarBonus.ChangePoskiRadara();
            HideRadar();//прячем радар
        }
    }
    public void HideRadar()//прячем радар
    {
        switch (ktoTyt)
        {
            case 1:
                RadarBonus.poska1 = false;
                return;
            case 2:
                RadarBonus.poska2 = false;
                return;
            case 3:
                RadarBonus.poska3 = false;
                return;
            case 4:
                RadarBonus.poska4 = false;
                return;
        }
        RadarBonus.ChangePoskiRadara();
    }
}
