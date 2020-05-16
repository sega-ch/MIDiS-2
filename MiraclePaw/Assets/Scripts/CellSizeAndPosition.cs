using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellSizeAndPosition : MonoBehaviour
{
    static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        size();
        //count++;
        //this.name += count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void size()
    {
        //this.transform.localScale = new Vector3(.125f, .125f, 0);
        this.gameObject.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-4.5f, 4.5f), 0);
    }


    #region Attempts to locate randomly generated prefabs
    //void PosChecker(Collision2D other) 
    //{
    //    if (other.gameObject.CompareTag("FieldCell"))
    //    {
    //        this.gameObject.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-4.5f, 4.5f), 0);
    //        PosChecker(other);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("it works" + this.gameObject.name + count);
    //    if (other.gameObject.CompareTag("FieldCell"))
    //    {
    //        this.gameObject.GetComponent<Rigidbody2D>().position = new Vector3(Random.Range(-6.6f, 6.6f), Random.Range(-5f, 5f), 0);

    //        Debug.Log("moved" + this.gameObject.transform.position);
    //        //Debug.Break();
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("FieldCell"))
    //    {
    //        this.gameObject.transform.position = new Vector3(Random.Range(-6.6f, 6.6f), Random.Range(-5f, 5f), 0);

    //        Debug.Log("moved");
    //    }
    //}
    #endregion
}