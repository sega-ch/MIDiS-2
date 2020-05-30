using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar_Triger : MonoBehaviour
{
    Joystic_touch joystic_Touch;
    private GameObject data;
    TreasureEditor treasureEditor;
    public GameObject radar;//полоска радара на которую реагирует скрипт
    Controller Controller; 

    private void Start()
    {
        joystic_Touch = GameObject.Find("Dog").GetComponent<Joystic_touch>();
        data = GameObject.Find("Data");
        treasureEditor = data.GetComponent<TreasureEditor>();

        Controller = GameObject.Find("Data").GetComponent<Controller>();
    }
    private void OnTriggerStay(Collider other)//если клад входит в зону действия радара
    {
        if (treasureEditor.purse == false && treasureEditor.amulet == false)//если не подобран кошель
        {
            if (other.gameObject.tag == "Klad")//проверяем что это клад по тегу
            {
                if(!Controller.SpeedChanged){
                joystic_Touch.speedMove -=  Controller.SpeedReduce;
                Controller.SpeedChanged = true;
                }
                if (!radar.activeSelf)
                {
                    radar.SetActive(true);//активируем полоску радара
                }
            }
        }
     }

    private void OnTriggerExit(Collider other)//если клад выходит из зоны действия радара
    {
        if (other.gameObject.tag == "Klad")//проверяем что это клад по тегу
        {
            if(Controller.SpeedChanged){
                joystic_Touch.speedMove += Controller.SpeedReduce;
                Controller.SpeedChanged = false;
                }
            if (radar.activeSelf)
            {
                radar.SetActive(false);//отключаем полоску радара
            }
        }
    }
}
