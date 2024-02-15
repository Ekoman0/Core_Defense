using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBoss : MonoBehaviour
{
    public float damage = 200;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Core" || collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "Factory" || collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "BigHealthRegen" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall")
        {
            
           
            if (collision.gameObject.GetComponent<Health>().IsHaventDragger == false)
            {
                if (collision.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {
                    collision.GetComponent<Health>().health -= damage;

                }
            }
            else
            {
                if (collision.gameObject.tag == "Core")
                {
                    collision.GetComponent<Health>().health -= damage*3;
                    Destroy(this.gameObject);
                }
                else
                {
                    collision.GetComponent<Health>().health -= damage;
                }
            }
        }
    }
    private void Update()
    {
        this.GetComponent<Transform>().Rotate(0, 0, 120 * Time.deltaTime);
    }
}
