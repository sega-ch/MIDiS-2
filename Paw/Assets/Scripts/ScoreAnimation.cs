using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreAnimation : MonoBehaviour
{
    private GameObject data;
    Controller Controller;
    public GameObject dog;
    public GameObject bone;
    public GameObject boneChill;
    public GameObject boneGold;
    public GameObject boneChillGold;
    TreasureEditor treasureEditor;
    public Animator k_Animator;
    public Animator kg_Animator;
    public GameObject scorePrefab;
    public static bool scoreGo = false;
    void Start()
    {
        data = GameObject.Find("Data");
        Controller = GameObject.Find("Data").GetComponent<Controller>();
        treasureEditor = data.GetComponent<TreasureEditor>();
    }

    public void Update()
    {
        if (treasureEditor.bone == true)
        {
            NachaloAnimacii();
            treasureEditor.bone = false;
        }
        if (treasureEditor.goldenBone == true)
        {
            NachaloAnimaciiGold();
            treasureEditor.goldenBone = false;
        }
    }
    
    public void NachaloAnimacii()
    {

        bone.transform.position = new Vector3(dog.transform.position.x, dog.transform.position.y, dog.transform.position.z + 12);
        bone.SetActive(true);
        k_Animator.SetBool("Yes", true);//Тригер анимации
        Invoke("NadoelaEtaAnimaciya", 1f);
        Invoke("AnimaciapodnatiaKladaMertva", 1.7f);
    }
    public void NachaloAnimaciiGold()
    {

        boneGold.transform.position = new Vector3(dog.transform.position.x, dog.transform.position.y, dog.transform.position.z + 12);
        boneGold.SetActive(true);
        kg_Animator.SetBool("Yes", true);//Тригер анимации
        Invoke("NadoelaEtaAnimaciyaGold", 1f);
        Invoke("AnimaciapodnatiaKladaMertvaGold", 1.7f);
    }
    public void NadoelaEtaAnimaciya()//Показываем кость, а то криво работает анимация
    {
        boneChill.GetComponent<MeshRenderer>().enabled = true;
    }
    public void AnimaciapodnatiaKladaMertva()//Вырубаем анимацию и все прячим
    {
        k_Animator.SetBool("Yes", false);
        boneChill.GetComponent<MeshRenderer>().enabled = false;
        bone.SetActive(false);
        PoyavlenieChastic();
    }
    public void NadoelaEtaAnimaciyaGold()//Показываем кость, а то криво работает анимация
    {
        boneChillGold.GetComponent<MeshRenderer>().enabled = true;
    }
    public void AnimaciapodnatiaKladaMertvaGold()//Вырубаем анимацию и все прячим
    {
        kg_Animator.SetBool("Yes", false);
        boneChillGold.GetComponent<MeshRenderer>().enabled = false;
        boneGold.SetActive(false);
        PoyavlenieChastic();
    }
    public void PoyavlenieChastic()//Появление префаба очков
    {
        scorePrefab.transform.position = new Vector3(dog.transform.position.x, dog.transform.position.y + 20.5f, dog.transform.position.z + 6);
        Instantiate(scorePrefab);
        scoreGo = true;
    }
}
