using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuild : MonoBehaviour
{
    private int Enemycounter = 0;
    private bool triggerstay=false;
    private bool attackCore = false;
    public bool inrange = false;
    public bool move = true;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float AttackTime;
    public float AttackTimeCount;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public Transform Shootpoint1;
    bool shoot1 = true;
    bool shoot2 = false;
    public float Force;
    private float MoveStopTimer;
    public bool corein=false;

    public AudioSource ShootSounds;
   

    // Start is called before the first frame update
    void Start()
    {
        AttackTimeCount = AttackTime;

        MoveStopTimer = Random.Range(0.1f, 1.14f);

    }

    void Update()
    {
        if (triggerstay == true)
        {
          
            
            if (attackCore == false)
            {
              FindClosestBuild();
            }

            

          
            inrange = true;
            Detected = true;
        }
        AttackTimeCount -= Time.deltaTime;
        if (corein == true)
        {
            

            MoveStopTimer -= Time.deltaTime;
            if (MoveStopTimer<=0)
            {
                move = false;
            }
        }

        if (Detected)
        {
            

            if (AttackTimeCount < 0f)
            {
                
                shoot();
                AttackTimeCount = AttackTime;
            }
        }

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "Factory" || collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "BigHealthRegen" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall" || collision.gameObject.tag == "UraniumDrill")
        {
            if (collision.gameObject.GetComponent<Dragger>())
            {
                if (collision.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {
                    
                    Enemycounter += 1;
                    triggerstay = true;
                    if (collision.gameObject.tag == "Core")
                    {

                        FindClosestCore();
                        attackCore = true;
                        corein = true;
                        
                        
                        
                    }
                }
            }
            else
            {
               
                Enemycounter += 1;
                triggerstay = true;
                if (collision.gameObject.tag == "Core")
                {

                    FindClosestCore();
                    attackCore = true;
                    corein = true;
                    
                }
            }
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "WoodenDrill"  || collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "Factory" ||  collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "BigHealthRegen" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall" || collision.gameObject.tag == "UraniumDrill")
        {
            
            if (triggerstay == true)
            {
                Enemycounter -= 1;
            }

            if (Enemycounter <= 0)
            {
                triggerstay = false;
            }
            //inrange = false;
            Detected = false;
            //triggerstay = false;


        }
    }

    void FindClosestBuild()
    {
        float distanceToClosestBuild = Mathf.Infinity;
        BuildCloses ClosestBuild = null;
        BuildCloses[] allBuild = GameObject.FindObjectsOfType<BuildCloses>();
        
        RaycastHit2D hit = Physics2D.Linecast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward));
        foreach (BuildCloses currentEnemy in allBuild)
        {
            if (currentEnemy.gameObject.GetComponent<BuildCloses>().enabled == true)
            {
                float distanceToOre = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToOre < distanceToClosestBuild)
                {
                    distanceToClosestBuild = distanceToOre;
                    ClosestBuild = currentEnemy;
                }

            }



        }
        Vector2 targetPos = ClosestBuild.transform.position;
        Direction = targetPos - (Vector2)transform.position;
        Gun.transform.up = Direction;
       
    }
    void FindClosestCore()
    {
        float distanceToClosestCore = Mathf.Infinity;
        CoreCloses ClosestCore= null;
        CoreCloses[] allCore = GameObject.FindObjectsOfType<CoreCloses>();

        RaycastHit2D hit = Physics2D.Linecast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward));
        foreach (CoreCloses currentEnemy in allCore)
        {
            float distanceToOre = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToOre < distanceToClosestCore)
            {
                distanceToClosestCore = distanceToOre;
                ClosestCore = currentEnemy;
            }

        }
        Vector2 targetPos = ClosestCore.transform.position;
        Direction = targetPos - (Vector2)transform.position;
        Gun.transform.up = Direction;

    }

    void shoot()
    {

        if (shoot1 == true && shoot2 == false)
        {
            if (ShootSounds != null)
            {
                ShootSounds.Play();
            }
            
            GameObject BulletIns = Lean.Pool.LeanPool.Spawn(bullet, Shootpoint.position, Quaternion.identity);
            BulletIns.GetComponent<Rigidbody2D>().velocity = Direction.normalized * Force;
            BulletIns.transform.up = Direction;

            Lean.Pool.LeanPool.Despawn(BulletIns, 1.5f);
            shoot1 = false;
            shoot2 = true;
        }
        else if (shoot2 == true && shoot1 == false)
        {
            ShootSounds.Play();
            GameObject BulletIns = Lean.Pool.LeanPool.Spawn(bullet, Shootpoint1.position, Quaternion.identity);
            BulletIns.GetComponent<Rigidbody2D>().velocity = Direction.normalized * Force;
            BulletIns.transform.up = Direction;

            Lean.Pool.LeanPool.Despawn(BulletIns, 1.5f);
            shoot1 = true;
            shoot2 = false;
        }




    }

}
