using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPlacement : MonoBehaviour
{
    public GameObject cellPref;
    public int cellsAmmount;
    Transform[] objects = new Transform[10];
    public float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        cellsAmmount = Random.Range(6, 15);

        #region ObjectsPositions
        //    objects[0] = GameObject.Find("Screenshot_2").GetComponent<Transform>();
        //    objects[1] = GameObject.Find("Screenshot_2 (1)").GetComponent<Transform>();
        //    objects[2] = GameObject.Find("Screenshot_2 (2)").GetComponent<Transform>();
        //    objects[3] = GameObject.Find("Screenshot_2 (3)").GetComponent<Transform>();
        //    objects[4] = GameObject.Find("Screenshot_2 (4)").GetComponent<Transform>();
        //    objects[5] = GameObject.Find("Screenshot_2 (5)").GetComponent<Transform>();
        //    objects[6] = GameObject.Find("Screenshot_2 (6)").GetComponent<Transform>();
        //    objects[7] = GameObject.Find("Screenshot_2 (7)").GetComponent<Transform>();
        //    objects[8] = GameObject.Find("Screenshot_2 (8)").GetComponent<Transform>();
        //    objects[9] = GameObject.Find("Screenshot_2 (9)").GetComponent<Transform>();
        #endregion

        #region CodeFromDoodleJumpForAlocatingPrefabs (Doesnt work yet)
        var objects = new List<UnityEngine.Vector3>();


        for (int i = 0; i < cellsAmmount; i++)
        {
            var point = Instantiate(cellPref, new Vector3(Random.Range(-6.6f, 6.6f), Random.Range(-5f, 5f), 0), Quaternion.identity);

            Debug.Log(i + " at " + point.transform.position);

            var colRememberer = point.GetComponent<CircleCollider2D>();

            int counter = 0;

            var minimumDist = 12f;

            for (int j = 0; j < objects.Count; j++)
            {
                var item = objects[j];


                counter++;


                if (counter > 50000)
                {
                    Debug.LogError(i+1);
                    Debug.Break();
                    break;
                }

                var dist = (point.transform.position - item).magnitude;

                if(dist<minimumDist) minimumDist = dist;

                if (/*colRememberer.OverlapCollider(new ContactFilter2D() { useTriggers = true }, new Collider2D[1000]) > 0 ||
                    colRememberer.IsTouchingLayers(8)*/  dist < 4)
                {
                    Debug.LogWarning(i + " distance " + dist + " to " + j);

                    point.transform.position = new Vector3(Random.Range(-6.6f, 6.6f), Random.Range(-5f, 5f), 0);


                    //objLink.GetComponent<Rigidbody2D>().AddForce();

                    colRememberer = point.GetComponent<CircleCollider2D>();

                    j = -1;

                    minimumDist = 12f;
                }
            }

            Debug.Log(i + " final " + point.transform.position + " minimum " + minimumDist);

            objects.Add(point.transform.position);
            //Debug.Break();
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
