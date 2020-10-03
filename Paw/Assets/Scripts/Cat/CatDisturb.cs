using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDisturb : MonoBehaviour
{
    public GameObject znak;
    CatAI CatAi;
    public bool catDistrub;
    void Start()
    {
        CatAi = GameObject.Find("Cat").GetComponent<CatAI>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cat")
        {
            ActiveZnak();
            catDistrub = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        DizActiveZnak();
        catDistrub = false;
    }
    void ActiveZnak()
    {
        znak.SetActive(true);
    }
    void DizActiveZnak()
    {
        znak.SetActive(false);
    }
}
