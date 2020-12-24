using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klad_Up : MonoBehaviour
{
    private GameObject data;
    TreasureEditor treasureEditor;
    GameObject dog;
    public static int podnatoKladov = 0;
    public GameObject PurseOnTheDog;
    public GameObject HatOnTheDogLeather;
    public GameObject HatOnTheDogStraw;
    Controller Controller;
    public static event ActionOnSpawnPoint OnSpawnPointFound;
    public delegate void ActionOnSpawnPoint(GameObject spawnPoint);
    #region GameplaySoundsEvents
    public static event DiggingSound Digging;
    public delegate IEnumerator DiggingSound();

    public static event HatFound ActivateHatSound;
    public delegate IEnumerator HatFound();

    public static event PurseFound ActivatePurseSound;
    public delegate IEnumerator PurseFound();
    #endregion
    Animator DogAnimator;
    public bool isCarringObject = false;
    private void Start()
    {
        DogAnimator = GameObject.Find("dog_model_step4_animation_static").GetComponent<Animator>();
        dog = GameObject.Find("Dog");
        data = GameObject.Find("Data");
        treasureEditor = data.GetComponent<TreasureEditor>();
        Controller = GameObject.Find("Data").GetComponent<Controller>();
    }

    private void OnTriggerEnter(Collider other)//зона на которой происходт потбор предмета
    {   if (treasureEditor.purse == false && treasureEditor.amulet == false)//если не подобран кошель
        {
            if (other.gameObject.tag == "Klad")//проверяем этот ли клад по тегу
            {
                if(other.gameObject.CompareTag("Klad")) AutoAllocator.currentPointsAmmountOnTheField--;
                
                if (OnSpawnPointFound != null)
                {
                    OnSpawnPointFound(other.gameObject);
                }

                Destroy(other.gameObject);//уничтажаем клад
                podnatoKladov++;
                if (treasureEditor.toStage1 < podnatoKladov || treasureEditor.toStage1 == 0)
                {
                    treasureEditor.Stages();//метод рандомного клада
                }
                else
                {
                    treasureEditor.bone = true;
                    treasureEditor.score = treasureEditor.score + Convert.ToInt32((25 * treasureEditor.pointMultiplier));
                    Controller.TreasureAmmount--;
                }

                Debug.Log("Очки " + podnatoKladov);
                Debug.Log("Кость " + treasureEditor.bone);
                Debug.Log("Золотая кость " + treasureEditor.goldenBone);
                Debug.Log("Кошелек " + treasureEditor.purse);
                Debug.Log("Амулет " + treasureEditor.amulet);

                StartCoroutine(Digging());
                treasureEditor.bone = false;
                treasureEditor.goldenBone = false;

                dog.gameObject.GetComponent<Joystic_touch>().enabled = false;//отключаем передвежение для анимации
                DogAnimator.SetBool("Walking", false);
                DogAnimator.SetBool("Digging", true);
                Invoke("Timef", 0.5f);//запускаем метод через две секунды (если примерно столько будет анимация)
            }
        }
    }

    public void Timef()//метод при котором мы включаем управление и убираем полоски радара
    {
        dog.gameObject.GetComponent<Joystic_touch>().enabled = true;

        dog.GetComponent<RadarBonus>().NullProperties();

        if(Controller.SpeedChanged)
        {
            dog.GetComponent<Joystic_touch>().speedMove += Controller.SpeedReduce;
            Controller.SpeedChanged = false;
        }
        DogAnimator.SetBool("Digging", false);
    }

    public void purse()
    {
        int dos = 0;
        dos = UnityEngine.Random.Range(0, 100);
        if (treasureEditor.purse == true && !isCarringObject && dos <= 50)
        {
            StartCoroutine(ActivatePurseSound());
            isCarringObject = true;
            PurseOnTheDog.SetActive(true);
        }
        if (treasureEditor.purse == true && !isCarringObject && dos >= 50)
        {
            StartCoroutine(ActivateHatSound());
            isCarringObject = true;
            int dosc = 0;
            dosc = UnityEngine.Random.Range(0, 100);
            if (dosc >= 50)
            {
                HatOnTheDogStraw.SetActive(true);
            }
            else
            {
                HatOnTheDogLeather.SetActive(true);
            }
        }
    }
}
