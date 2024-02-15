using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour
{
    public bool IsBoss;
    List<GameObject> inbuild = new List<GameObject>();
    public bool bombermantriggerenter = false;
    public ParticleSystem explosiveeffect;


    private void Update()
    {
        if (bombermantriggerenter)
        {
            Instantiate(explosiveeffect, this.transform.position, Quaternion.identity);
            for (int i = 0; i < inbuild.Count; i++)
            {

                if (inbuild[i] != null)
                {
                    if (inbuild[i].gameObject.tag == "IronWall")
                    {
                        inbuild[i].GetComponent<Health>().health -= 150;
                    }
                    else if (inbuild[i].gameObject.tag == "Player")
                    {
                        inbuild[i].GetComponent<Health>().health -= 500;
                    }
                    else
                    {
                        inbuild[i].GetComponent<Health>().health -= 50;
                    }
                   
                }
                



            }
            if (IsBoss == true)
            {

                Lean.Pool.LeanPool.Despawn(transform.parent.gameObject);
            }
            Destroy(transform.parent.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall" || collision.gameObject.tag == "UraniumDrill")
        {
            if (collision.gameObject.GetComponent<Health>().IsHaventDragger== false)
            {
                 if (collision.gameObject.GetComponent<Dragger>().Isbuilded == true)
                 {
                     inbuild.Add(collision.gameObject);

                 }
            }
            else
            {
                inbuild.Add(collision.gameObject);
            }
           


        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall" || collision.gameObject.tag == "UraniumDrill")
        {
            inbuild.Remove(collision.gameObject);


        }
    }
}
