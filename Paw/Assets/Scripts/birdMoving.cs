using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class birdMoving : MonoBehaviour
{
    public GameObject bird;
    public GameObject dog;

    // Start is called before the first frame update
    void Start()
    {
        //Определяем позицию чайки
        Vector3 birdPosition = bird.transform.position;
        Debug.Log("Позиция чайки = " + birdPosition);

        //Определяем позицию собаки
        Vector3 dogPosition = dog.transform.position;
        Debug.Log("Позиция собаки = " + dogPosition);
    }

    // Update is called once per frame
    void Update()
    {
      //Двигаем чайку к собаке
      Vector3 positionMoving = birdPosition
            
    }
}
