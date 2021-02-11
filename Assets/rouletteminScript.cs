using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rouletteminScript : MonoBehaviour
{
    public int passLeft, peekLeft, spinLeft;
    public string faceNormal, faceTense, faceDead;
    public int myNum;
    public GameObject placeInLine;
    [SerializeField] float lerpSpeed;
    public bool dead = false;
    Animator anim;
    [SerializeField] Text myName;


    private void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.name = "roulettemin " + myNum;
        myName.text = myNum.ToString();
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, placeInLine.transform.position, lerpSpeed);
        anim.SetBool("dead", dead);
    }
}
