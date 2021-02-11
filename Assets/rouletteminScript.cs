using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteminScript : MonoBehaviour
{
    public int passLeft, peekLeft, spinLeft;
    public string faceNormal, faceTense, faceDead;
    public int myNum;
    public GameObject placeInLine;
    [SerializeField] float lerpSpeed;
    public bool dead = false;
    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, placeInLine.transform.position, lerpSpeed);
        anim.SetBool("dead", dead);
    }
}
