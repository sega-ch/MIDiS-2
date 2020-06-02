using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CatAI : MonoBehaviour
{
    public float speed = 40.0f;
    public float obastacleRange = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < obastacleRange)
            {
                float angle = UnityEngine.Random.Range(-100, 100);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
