using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    //will switch to new input system when I have time.
    [Header("Set in Inpsector")]
    public GameObject prefabProjectile;


    [Header("Set Dynamically")] 
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimMode;


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
        projectile.GetComponent<Rigidbody>().isKinematic=true;
    }
}
