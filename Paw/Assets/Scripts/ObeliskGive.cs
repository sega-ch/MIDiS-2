using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskGive : MonoBehaviour
{
<<<<<<< HEAD
    Controller Controller;
=======
>>>>>>> 02e6cb272fcad83368a58c57bc5c6520f7870609
    private GameObject data;
    TreasureEditor treasureEditor;
    GameObject dog;//псина
    public GameObject strelka;
    void Start()
    {
<<<<<<< HEAD
        Controller = GameObject.Find("Data").GetComponent<Controller>();
=======
>>>>>>> 02e6cb272fcad83368a58c57bc5c6520f7870609
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
<<<<<<< HEAD

                strelka.SetActive(false);
                Invoke("TimeT", 0.5f);
=======
                strelka.SetActive(false);
                Invoke("TimeT", 2);
>>>>>>> 02e6cb272fcad83368a58c57bc5c6520f7870609
            }
        }
    }
    void TimeT()//мто что мы запускаем через время
    {
        dog.gameObject.GetComponent<Joystic_touch>().enabled = true;
    }
}
