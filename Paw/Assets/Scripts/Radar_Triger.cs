using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar_Triger : MonoBehaviour
{
    public GameObject radar;//полоска радара на которую реагирует скрипт

    private void OnTriggerStay(Collider other)//если клад входит в зону действия радара
    {
        if (Klad_Up.koshelokUp == false)//если не подобран кошель
        {
            if (other.gameObject.tag == "Klad" || other.gameObject.tag == "KladGold" || other.gameObject.tag == "Koshelok")//проверяем что это клад по тегу
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
        if (other.gameObject.tag == "Klad" || other.gameObject.tag == "KladGold" || other.gameObject.tag == "Koshelok")//проверяем что это клад по тегу
        {
            if (radar.activeSelf)
            {
                radar.SetActive(false);//отключаем полоску радара
            }
        }
    }
}
