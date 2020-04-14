using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPlacement : MonoBehaviour
{
    public GameObject cellPref;
    public int cellsAmmount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cellsAmmount; i++)
        {
            Instantiate(cellPref);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void JustTryingToPlaceCells()
    {
        
    }

    //void size()
    //{
    //    cellPref.transform.localScale = new Vector3(.5f, .5f, .5f);
    //    cellPref.gameObject.transform.position = new Vector3(Random.Range(-512,512), Random.Range(-384,384), 0);
    //}
}
