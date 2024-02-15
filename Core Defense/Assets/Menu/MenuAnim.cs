using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuAnim : MonoBehaviour
{
    private Transform targetposition;
    Vector2 Direction;
    float timer = 6f;
    // Start is called before the first frame update
    void Start()
    {
        targetposition = GameObject.Find("TARGET").transform;

       

        this.gameObject.transform.DOMove(targetposition.position, 7);
        Direction = (Vector2)targetposition.transform.position - (Vector2)transform.position;

        this.transform.up = Direction;


    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer<0)
        {
            Destroy(this.gameObject);
        }   
    }
   
}
