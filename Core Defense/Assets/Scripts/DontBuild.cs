using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Grid))]
public class DontBuild : MonoBehaviour
{
    public  bool dragnobuild = false;

    Vector3 mousePos;
    Vector3 mousePos2;
    public static DontBuild Instance2 { get; private set; }

    public void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance2 != null && Instance2 != this)
        {
            Destroy(this);
        }
        else
        {
            Instance2 = this;
        }
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);// bug çözmek için
        mousePos2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
    



    private void OnMouseDown()
    {
         mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
    private void OnMouseUp()
    {
        mousePos2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    //mouseyi týkladýmýz da ve kaldýrdýðýmýzdaki yerler eþit deðilse build yapmýyoruz

    private void Update()
    {
        
        if (mousePos != mousePos2) 
        {
            dragnobuild = true;
            
        }
        else if (mousePos == mousePos2)
        {
            
            dragnobuild = false;
            
            changemousposition();
              
            
            
        }
               
    }

    private void changemousposition() // bug çözmek için
    {
        mousePos = new Vector3(1, 1, 0);
        mousePos2 = new Vector3(2, 2, 0);
    }

 

}
