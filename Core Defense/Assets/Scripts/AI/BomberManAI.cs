using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberManAI : MonoBehaviour
{
    public GameObject range;
    Vector2 Direction;
    private bool move = true;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        FindClosestBuild();
        direction.Normalize();
        movement = direction;
    }
    void FindClosestBuild()
    {
       
            float distanceToClosestBuild = Mathf.Infinity;
            BuildCloses ClosestBuild = null;
            BuildCloses[] allBuild = GameObject.FindObjectsOfType<BuildCloses>();

            RaycastHit2D hit = Physics2D.Linecast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward));
            foreach (BuildCloses currentEnemy in allBuild)
            {
                float distanceToOre = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToOre < distanceToClosestBuild)
                {
                    distanceToClosestBuild = distanceToOre;
                    ClosestBuild = currentEnemy;
                }

            }
            Vector2 targetPos = ClosestBuild.transform.position;
            Direction = targetPos - (Vector2)transform.position;
            this.transform.up = Direction;



        


    }
    private void FixedUpdate()
    {
        if (move == true)
        {
            moveCharacter(Direction);
        }

    }
    void moveCharacter(Vector2 direction)
    {

        rb.MovePosition((Vector2)transform.position + (direction.normalized * moveSpeed * Time.deltaTime));


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "WoodenDrill"  || collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "Factory" ||  collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "BigHealthRegen" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall" || collision.gameObject.tag == "UraniumDrill")
        {
            range.GetComponent<Bomberman>().bombermantriggerenter = true;
        }
    }



}
    