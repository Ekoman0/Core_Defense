/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDeneme : MonoBehaviour
{

    public bool isTurret;
    private bool BuildBlocked = false;
    private bool dragging = false;

    private  float dragingnoattacktimer = 2f;
    public bool dragingnoattack = false;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float AttackTime;
    public float AttackTimeCount;
    public Transform Shootpoint;
    public Transform Shootpoint1;
    bool shoot1 = true;
    bool shoot2 = false;
    public float Force;
    // Start is called before the first frame update
    void Start()
    {
        AttackTimeCount = AttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.gameObject);
        if (isTurret== true)
        {
            BuildBlocked = Gun.GetComponent<Dragger>().BuildBlocked;
            dragging = Gun.GetComponent<Dragger>().draging;
        }
        else
        {
            dragging = false;
        }
        
        
        AttackTimeCount -= Time.deltaTime;
        if (dragging == true)
        {
            dragingnoattack = true;
            dragingnoattacktimer = 2f;
        }
        dragingnoattacktimer -= Time.deltaTime;
        if (dragingnoattacktimer <0 )
        {
            dragingnoattack = false;
        }

        if (Detected && dragingnoattack == false && BuildBlocked == false)
        {
            
            
            if (AttackTimeCount <0f)
            {
                  
                shoot();
                AttackTimeCount = AttackTime;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            
            //Gun.transform.up = Direction;
            FindClosestEnemy();
            //Target[0] = collision.gameObject;

            Detected = true;


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            //Gun.transform.up = Direction;
            //FindClosestBuild();
            //Target[0] = collision.gameObject;

            Detected = false;


        }
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        EnemyCloses ClosestEnemy = null;
        EnemyCloses[] allEnemy = GameObject.FindObjectsOfType<EnemyCloses>();

        RaycastHit2D hit = Physics2D.Linecast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward));
        foreach (EnemyCloses currentEnemy in allEnemy)
        {
            float distanceToOre = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToOre < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToOre;
                ClosestEnemy = currentEnemy;
            }

        }
        Vector2 targetPos = ClosestEnemy.transform.position;
        Direction = targetPos - (Vector2)transform.position;
        Gun.transform.up = Direction;
        //Build.transform.position = new Vector3(ClosestOre.transform.position.x, ClosestOre.transform.position.y, -1f);
        //Debug.DrawLine(Player.transform.position, ClosestOre.transform.position);
    }

    void shoot()
    {
        
            if (shoot1 == true && shoot2 == false)
            {

                GameObject BulletIns = Lean.Pool.LeanPool.Spawn(bullet, Shootpoint.position, Quaternion.identity);
                BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
                 Lean.Pool.LeanPool.Despawn(BulletIns, 4f);
                shoot1 = false;
                shoot2 = true;
            }
            else if (shoot2 == true && shoot1 == false)
            {

                GameObject BulletIns = Lean.Pool.LeanPool.Spawn(bullet, Shootpoint1.position, Quaternion.identity);
                BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
                Lean.Pool.LeanPool.Despawn(BulletIns, 4f);
                shoot1 = true;
                shoot2 = false;
            }
        
        
        
        
    }

}
*/