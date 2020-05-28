using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurseCarry : MonoBehaviour
{
    public GameObject PurseOnTheDog;
    public GameObject HatOnTheDog;
    public bool isCarringObject = false;

    void Start() {

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Purse") && !isCarringObject){
            isCarringObject = true;
            PurseOnTheDog.SetActive(true);
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("Hat") && !isCarringObject){
            isCarringObject = true;
            HatOnTheDog.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
