using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hozain_Give : MonoBehaviour
{
    public GameObject dog;//псина
    public GameObject strelka1;
    public GameObject strelka2;
    private void OnTriggerEnter(Collider other)//зона на которой происходт потбор предмета
    {
        if (Klad_Up.koshelokUp == true)
        {
            if (other.gameObject.tag == "Hozain_1" || other.gameObject.tag == "Hozain_2")//проверяем этот ли объект по тегу
            {
                Debug.Log("Есть пробитие!");
                dog.gameObject.GetComponent<Joystic_touch>().enabled = false;//отключаем передвежение для анимации
                Klad_Up.koshelokUp = false;
                strelka1.SetActive(false);
                strelka2.SetActive(false);
                Invoke("TimeT", 2);
            }
        }
    }
    void TimeG()//мто что мы запускаем через время
    {
        Klad_Up klad_Up = new Klad_Up();
        klad_Up.Timef();
    }
    void TimeT()//мто что мы запускаем через время
    {
        dog.gameObject.GetComponent<Joystic_touch>().enabled = true;
    }
}
