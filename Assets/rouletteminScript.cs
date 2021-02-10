using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteminScript : MonoBehaviour
{
    public int passLeft, peekLeft, spinLeft;
    public string faceNormal, faceTense, faceDead;
    public int myNum;
    public GameObject placeInLine;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = placeInLine.transform.position;
    }
}
