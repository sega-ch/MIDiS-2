using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSizeAndPosition : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
        size();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void size()
    {
        
        this.transform.localScale = new Vector3(.5f, .5f, .5f);
        this.gameObject.transform.position = new Vector3(Random.Range(-6f , 6f), Random.Range(-4.5f,4.5f), 0);
        
    }
}