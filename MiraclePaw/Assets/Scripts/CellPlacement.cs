using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPlacement : MonoBehaviour
{
    public GameObject cellPref;
    public static int cellsAmmount;
    public static int cellAmmoun;
    Transform[] objects = new Transform[10];
    public float distance;

    // Start is called before the first frame update
    void Start()
    { 
        objects[0] = GameObject.Find("Screenshot_2").GetComponent<Transform>();
        objects[1] = GameObject.Find("Screenshot_2 (1)").GetComponent<Transform>();
        objects[2] = GameObject.Find("Screenshot_2 (2)").GetComponent<Transform>();
        objects[3] = GameObject.Find("Screenshot_2 (3)").GetComponent<Transform>();
        objects[4] = GameObject.Find("Screenshot_2 (4)").GetComponent<Transform>();
        objects[5] = GameObject.Find("Screenshot_2 (5)").GetComponent<Transform>();
        objects[6] = GameObject.Find("Screenshot_2 (6)").GetComponent<Transform>();
        objects[7] = GameObject.Find("Screenshot_2 (7)").GetComponent<Transform>();
        objects[8] = GameObject.Find("Screenshot_2 (8)").GetComponent<Transform>();
        objects[9] = GameObject.Find("Screenshot_2 (9)").GetComponent<Transform>();
        for (int i = 0; i < cellsAmmount; i++)
        {
            Instantiate(cellPref);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                distance = Vector3.Distance(objects[i].position, objects[j].position); 
                Debug.Log("Расстояние = " + distance);
                Debug.Log("I =" + i + ";" + "J =" + j);
            }
           
        }
        
    }

    void JustTryingToPlaceCells()
    {

    }
}
