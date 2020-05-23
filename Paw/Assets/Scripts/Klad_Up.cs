using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klad_Up : MonoBehaviour
{
    public GameObject dog;//псина
    public GameObject rad1;//полоски радара
    public GameObject rad2;
    public GameObject rad3;
    public GameObject rad4;
    public static int podnatoKladov = 0;
    public static bool koshelokUp = false; //поднят ли кошелек
    private void OnTriggerEnter(Collider other)//зона на которой происходт потбор предмета
    {   if (koshelokUp == false)//если не подобран кошель
        {
            if (other.gameObject.tag == "Klad")//проверяем этот ли клад по тегу
            {
                if(other.gameObject.CompareTag("Klad")) AutoAllocator.currentPointsAmmountOnTheField--;
                Debug.Log(AutoAllocator.currentPointsAmmountOnTheField);
                Debug.Log("Есть пробитие!");
                Destroy(other.gameObject);//уничтажаем клад
                podnatoKladov++;
                if (RedactorKlada.Do_stadii_1 <= podnatoKladov && RedactorKlada.Do_stadii_2 < podnatoKladov)
                {
                    byte vibor;
                    vibor = gameObject.GetComponent<RedactorKlada>().Stadiya(RedactorKlada.Kosto4ka_1, RedactorKlada.ZolotayaKosto4ka_1, RedactorKlada.Koshelok_1, RedactorKlada.Amylet_1);
                    
                }
                if (RedactorKlada.Do_stadii_1 <= podnatoKladov && RedactorKlada.Do_stadii_2 < podnatoKladov)
                {
                    gameObject.GetComponent<RedactorKlada>().Stadiya(RedactorKlada.Kosto4ka_1, RedactorKlada.ZolotayaKosto4ka_1, RedactorKlada.Koshelok_1, RedactorKlada.Amylet_1);

                }
                if (RedactorKlada.Do_stadii_1 <= podnatoKladov && RedactorKlada.Do_stadii_2 < podnatoKladov)
                {
                    gameObject.GetComponent<RedactorKlada>().Stadiya(RedactorKlada.Kosto4ka_1, RedactorKlada.ZolotayaKosto4ka_1, RedactorKlada.Koshelok_1, RedactorKlada.Amylet_1);
                    
                }
                if (RedactorKlada.Do_stadii_1 <= podnatoKladov && RedactorKlada.Do_stadii_2 < podnatoKladov)
                {
                    gameObject.GetComponent<RedactorKlada>().Stadiya(RedactorKlada.Kosto4ka_1, RedactorKlada.ZolotayaKosto4ka_1, RedactorKlada.Koshelok_1, RedactorKlada.Amylet_1);

                }
                dog.gameObject.GetComponent<Joystic_touch>().enabled = false;//отключаем передвежение для анимации
                Invoke("Timef", 2);//запускаем метод через две секунды (если примерно столько будет анимация)
            }
            if (other.gameObject.tag == "Koshelok") //если это косшелек
            {
                koshelokUp = true;
                dog.gameObject.GetComponent<Joystic_touch>().enabled = false;
                Invoke("Timef", 2);
            }
        }
        

    }
        public void Timef()//метод при котором мы включаем управление и убираем полоски радара
        {
        dog.gameObject.GetComponent<Joystic_touch>().enabled = true;
        if (rad1.activeSelf)
        {
            rad1.SetActive(false);
        }
        if (rad2.activeSelf)
        {
            rad2.SetActive(false);
        }
        if (rad3.activeSelf)
        {
            rad3.SetActive(false);
        }
        if (rad4.activeSelf)
        {
            rad4.SetActive(false);
        }
        }
}
