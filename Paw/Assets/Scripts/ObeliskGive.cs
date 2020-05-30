using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskGive : MonoBehaviour
{
    private GameObject data;
    TreasureEditor treasureEditor;
    GameObject dog;//псина
    public GameObject strelka;
    void Start()
    {
        dog = GameObject.Find("Dog");
        data = GameObject.Find("Data");
        treasureEditor = data.GetComponent<TreasureEditor>();
    }

    private void OnTriggerEnter(Collider other)//зона на которой происходт потбор предмета
    {
        if (treasureEditor.amulet == true)
        {
            if (other.gameObject.tag == "Obelisk")//проверяем этот ли объект по тегу
            {
                dog.gameObject.GetComponent<Joystic_touch>().enabled = false;//отключаем передвежение для анимации
                treasureEditor.amulet = false;
                treasureEditor.score = treasureEditor.score + 40;
                strelka.SetActive(false);
                Invoke("TimeT", 2);
            }
        }
    }
    void TimeT()//мто что мы запускаем через время
    {
        dog.gameObject.GetComponent<Joystic_touch>().enabled = true;
    }
}
