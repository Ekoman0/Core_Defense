using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthRegen : MonoBehaviour
{
    public ParticleSystem regenps;
    public List<GameObject> objects;//Etraftaki objeler bu listenin içine alýnýr 

    private float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {

        

            if (objects.Count > 0)
            {
                if (timer < 0)
                {
                    for (int i = 0; i < objects.Count; i++)
                    {
                        //if (GameManager.GetComponent<BuildSystem>().ElectricBalance > 10)

                        if (objects[i].GetComponent<Health>().health < objects[i].GetComponent<Health>().initHealth)
                        {


                            regenps.Play();

                            objects[i].GetComponent<Health>().health += 40;                            
                            timer = 1.7f;





                        }



                    }
                }

            }
        
        if (timer > -1)
        {
            timer -= Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            objects.Add(collision.gameObject);
            Debug.Log(collision.gameObject.name + "Eklendi");
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" )
        {
            objects.Remove(collision.gameObject);
            Debug.Log(collision.gameObject.name + "Çýkarýldý");
        }
    }
}
