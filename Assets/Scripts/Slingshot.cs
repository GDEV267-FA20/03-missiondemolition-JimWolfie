using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    //will switch to new input system when I have time. 
    public GameObject launchPoint;


    void Awake()
    {
        Transform launchPointTransform = transform.Find("Launch");
        launchPoint = launchPointTransform.gameObject;
        launchPoint.SetActive(false);
    }
    void OnMouseEnter()
    {
        launchPoint.SetActive(true);
    }
    void OnMouseExit()
    {
        launchPoint.SetActive(false);
    }
}
