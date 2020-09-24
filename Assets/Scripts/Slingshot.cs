using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    //will switch to new input system when I have time.
    [Header("Set in Inpsector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    [Header("Set Dynamically")] 
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimMode;
    private Rigidbody projectileRB;


    void Awake()
    {
        Transform launchPointTransform = transform.Find("Launch");
        launchPoint = launchPointTransform.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTransform.position;
    }
    void OnMouseEnter()
    {
        launchPoint.SetActive(true);
    }
    void OnMouseExit()
    {
        launchPoint.SetActive(false);
    }
    private void OnMouseDown()
    {
        aimMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = launchPos;
        
        projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.isKinematic = true;
    }
    private void Update()
    {
        if(!aimMode)return;
        Vector3 mouse2D = Input.mousePosition;
        mouse2D.z = Camera.main.transform.position.z;
        Vector3 mouse3D = Camera.main.ScreenToWorldPoint(mouse2D);

        Vector3 mDelta = mouse3D - launchPos;
        float maxMag = this.GetComponent<SphereCollider>().radius;
        if(mDelta.magnitude >maxMag)
        {
            mDelta.Normalize();
            mDelta *= maxMag;
        }

        Vector3 projPos = launchPos +mDelta;
        projectile.transform.position = projPos;

        if(Input.GetMouseButtonUp(0))
        {
            aimMode = false;
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mDelta*velocityMult;
            projectile = null;
        }
    }        
}
