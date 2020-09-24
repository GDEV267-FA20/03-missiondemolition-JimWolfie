using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set dynamically")]
    public float camZ;

    void Awake()
    {
        camZ = this.transform.position.z;
    }
    void FixedUpdate()
    {
        if(POI==null)return;

        Vector3 destination = POI.transform.position;
        destination.z = camZ;
        transform.position = destination;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
