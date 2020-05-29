using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar_Triger : MonoBehaviour
{
    private GameObject data;
    TreasureEditor treasureEditor;
    public GameObject radar;//полоска радара на которую реагирует скрипт

    private void Start()
    {
        data = GameObject.Find("Data");
        treasureEditor = data.GetComponent<TreasureEditor>();
    }
    private void OnTriggerStay(Collider other)//если клад входит в зону действия радара
    {
        if (treasureEditor.purse == false)//если не подобран кошель
        {
            if (other.gameObject.tag == "Klad")//проверяем что это клад по тегу
            {
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
            if (radar.activeSelf)
            {
                radar.SetActive(false);//отключаем полоску радара
            }
        }
    }
}
