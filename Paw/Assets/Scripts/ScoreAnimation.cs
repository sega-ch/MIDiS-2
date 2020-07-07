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
    public GameObject cameras;
    TreasureEditor treasureEditor;
    public Animator k_Animator;
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
        
    }
    
    public void NachaloAnimacii()
    {

        bone.transform.position = new Vector3(dog.transform.position.x, dog.transform.position.y, dog.transform.position.z + 6);
        bone.SetActive(true);
        k_Animator.SetBool("Yes", true);
        Invoke("NadoelaEtaAnimaciya", 1f);
        Invoke("AnimaciapodnatiaKladaMertva", 1.7f);
    }
    public void NadoelaEtaAnimaciya()
    {
        boneChill.GetComponent<MeshRenderer>().enabled = true;
    }
    public void AnimaciapodnatiaKladaMertva()
    {
        k_Animator.SetBool("Yes", false);
        boneChill.GetComponent<MeshRenderer>().enabled = false;
        bone.SetActive(false);
        PoyavlenieChastic();
    }
    public void PoyavlenieChastic()
    {
        scorePrefab.transform.position = new Vector3(dog.transform.position.x, dog.transform.position.y + 20.5f, dog.transform.position.z + 6);
        Instantiate(scorePrefab);
        scoreGo = true;
    }
}
