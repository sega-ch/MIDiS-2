using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatGo : MonoBehaviour
{
    public GameObject ext;
    Vector3 extVec;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        extVec = ext.transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(extVec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
