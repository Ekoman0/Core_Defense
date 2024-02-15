using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBullet : MonoBehaviour
{
   
    List<GameObject> inbuild = new List<GameObject>();
    public bool bombermantriggerenter = false;
    public ParticleSystem explosiveeffect;
    public bool isUranium;

    private void Update()
    {
        if (bombermantriggerenter)
        {
            Instantiate(explosiveeffect, this.transform.position, Quaternion.identity);
            for (int i = 0; i < inbuild.Count; i++)
            {

                if (inbuild[i] != null)
                {
                    if (inbuild[i].gameObject.tag == "Enemy")
                    {
                        if (isUranium)
                        {
                            inbuild[i].GetComponent<Health>().health -= 110;
                        }
                        else
                        {
                            inbuild[i].GetComponent<Health>().health -= 50;
                        }
                       
                    }
                   

                }




            }

            bombermantriggerenter = false;
                Lean.Pool.LeanPool.Despawn(transform.parent.gameObject);
            
            
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
                    inbuild.Add(collision.gameObject);

             



        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            inbuild.Remove(collision.gameObject);


        }
    }
}
