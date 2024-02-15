using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Vector3 lastSpeed = new Vector3();
    private bool inrange;
    Vector2 Direction;
    private bool move = true;
    public GameObject Range;
    private GameObject core;
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

        lastSpeed = this.gameObject.transform.position;
        if (Range != null)
        {
            move = Range.gameObject.GetComponent<AttackBuild>().move;
            inrange = Range.gameObject.GetComponent<AttackBuild>().inrange;
        }
       
        core = GameObject.FindGameObjectWithTag("Core");
        if (core != null )
        {
              
             direction = core.transform.position - transform.position;
        }

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        if (Range != null)
        {
            FindClosestBuild();
        }
       
        direction.Normalize();
        movement = direction;
    }
    void FindClosestBuild()
    {
        if (inrange == false)
        {
            float distanceToClosestBuild = Mathf.Infinity;
            CoreCloses ClosestBuild = null;
            CoreCloses[] allBuild = GameObject.FindObjectsOfType<CoreCloses>();

            RaycastHit2D hit = Physics2D.Linecast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward));
            foreach (CoreCloses currentEnemy in allBuild)
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
        

    }
    private void FixedUpdate()
    {
        if (move == true)
        {
            moveCharacter(movement);
        }
       
    }
    void moveCharacter(Vector2 direction)
    {

            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        
        
    }
  
}