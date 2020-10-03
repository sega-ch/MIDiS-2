﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar_Triger : MonoBehaviour
{
    Joystic_touch joystic_Touch;
    private GameObject data;
    TreasureEditor treasureEditor;
    CatDisturb CatDisturb;
    public GameObject radar;//полоска радара на которую реагирует скрипт
    Controller Controller;
    public GameObject teni1;
    public GameObject teni2;
    public GameObject teni3;
    public GameObject teni4;
    private void Start()
    {
        joystic_Touch = GameObject.Find("Dog").GetComponent<Joystic_touch>();
        data = GameObject.Find("Data");
        treasureEditor = data.GetComponent<TreasureEditor>();
        Controller = GameObject.Find("Data").GetComponent<Controller>();
        CatDisturb = GameObject.Find("CatDisturbCol").GetComponent<CatDisturb>();
        
    }
    private void OnTriggerStay(Collider other)//если клад входит в зону действия радара
    {
        if (treasureEditor.purse == false && treasureEditor.amulet == false && CatDisturb.catDistrub == false)//если не подобран кошель или амулет или кот мешает
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
                    teni1.SetActive(true);teni2.SetActive(true);teni3.SetActive(true);teni4.SetActive(true);//активируем тени
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
