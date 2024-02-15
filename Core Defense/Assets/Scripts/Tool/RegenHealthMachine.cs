using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class RegenHealthMachine : MonoBehaviour
{
    public GameObject Parent;
    private GameObject GameManager;
    public ParticleSystem regenps;
    public List<GameObject> objects;//Etraftaki objeler bu listenin içine alýnýr 
    
    private float timer =2f;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.GetComponent<BuildSystem>().ElectricBalance >=10)
        {

            if (Parent.GetComponent<Dragger>().Isbuilded == true)
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

                                if (objects[i].tag == "Core")
                                {
                                    regenps.Play();

                                    objects[i].GetComponent<Health>().health += 4;
                                    GameManager.GetComponent<BuildSystem>().ElectricBalance -= 10;
                                    timer = 2f;
                                }
                                else
                                {
                                    regenps.Play();

                                    objects[i].GetComponent<Health>().health += 10;
                                    GameManager.GetComponent<BuildSystem>().ElectricBalance -= 10;
                                    timer = 2f;
                                }


                                





                            }



                        }
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
        if (collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "Factory" || collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "BigHealthRegen" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall" || collision.gameObject.tag == "UraniumDrill")
        {
            objects.Add(collision.gameObject);
            Debug.Log(collision.gameObject.name+ "Eklendi");
        }

        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "WoodenDrill"|| collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "Factory" || collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "BigHealthRegen" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall" || collision.gameObject.tag == "UraniumDrill")
        {
            objects.Remove(collision.gameObject);
            
        }
    }
    
}
