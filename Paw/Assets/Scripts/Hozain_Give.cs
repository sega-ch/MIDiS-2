using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hozain_Give : MonoBehaviour
{
    Joystic_touch joystic_Touch;
    private GameObject data;
    TreasureEditor treasureEditor;
    GameObject dog;
    public GameObject strelka1;
    public GameObject strelka2;
    public GameObject purseOnTheDog;
    public GameObject hatOnTheDog;
    public GameObject strawhatOnTheDog;
    Controller Controller;

    private void Start()
    {
        Controller = GameObject.Find("Data").GetComponent<Controller>();
        dog = GameObject.Find("Dog");
        data = GameObject.Find("Data");
        joystic_Touch = GameObject.Find("Dog").GetComponent<Joystic_touch>();
        treasureEditor = data.GetComponent<TreasureEditor>();
    }
    private void OnTriggerEnter(Collider other)//зона на которой происходт потбор предмета
    {
        if (treasureEditor.purse == true)
        {
            if (other.gameObject.tag == "Hozain_1" || other.gameObject.tag == "Hozain_2")//проверяем этот ли объект по тегу
            {
                Debug.Log("Есть пробитие!");
                dog.gameObject.GetComponent<Joystic_touch>().enabled = false;//отключаем передвежение для анимации
                treasureEditor.purse = false;
                GameObject.Find("eat").GetComponent<Klad_Up>().isCarringObject = false;
                treasureEditor.score = treasureEditor.score + Convert.ToInt32((50 * treasureEditor.pointMultiplier));
                Controller.TreasureAmmount--;
                joystic_Touch.speedMove = joystic_Touch.speedMove + (joystic_Touch.speedMove / 2);
                Invoke("EndOfEffect", 8);
                if (purseOnTheDog.activeSelf)
                {
                    purseOnTheDog.SetActive(false);
                }
                if (hatOnTheDog.activeSelf)
                {
                    hatOnTheDog.SetActive(false);
                }
                if (strawhatOnTheDog.activeSelf)
                {
                    strawhatOnTheDog.SetActive(false);
                }
                GameObject.Find("eat").GetComponent<Klad_Up>().isCarringObject = false;
                strelka1.SetActive(false);
                strelka2.SetActive(false);
                Invoke("TimeT", 0.5f);
            }
        }
    }
    void TimeT()//мто что мы запускаем через время
    {
        dog.gameObject.GetComponent<Joystic_touch>().enabled = true;
    }
    void EndOfEffect()
    {
        joystic_Touch.speedMove = joystic_Touch.speedMove - (joystic_Touch.speedMove / 2);
    }
}
