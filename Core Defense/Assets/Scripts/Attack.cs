using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    new List<GameObject> bullets;
    GameObject targetPos;

   [Header("Laser")]
    public bool islaser;
    public LineRenderer Linerenderer;
    float lasershoottimer;
    float laserhit;
    float laserElectricBalance;
    public bool isUraniumLaser;
    [Header("Mortar")]
    public bool isMortar;




    GameObject BulletIns;
    private int Enemycounter = 0; //turret�n alan�ndaki d��manlar� sayar
    private bool triggerstay=false; //turret�n ontriggerstay fonksiyonunu halleder(performans i�in ontriggerstay kullanm�yorum)
    public bool isTurret;//bu obje turret m� ?
    private bool BuildBlocked = false; //e�er turret ise herhangi bir objeye de�iyor mu
    private bool dragging = false;

  
    bool Detected = false; // d��man� detect etmek i�in
    Vector2 Direction;// turret� d��mana d�nd�rmek i�in
    public GameObject Gun; //turret
    public GameObject Parent;//turret�n babas�
    public GameObject bullet;
    private GameObject gamemanager;
    public float AttackTime;// ate� etme zaman�
    private float AttackTimeCount;//�sttekine fix
    public Transform Shootpoint;
    public Transform Shootpoint1;
    bool shoot1 = true;
    bool shoot2 = false;
    public float Force;

    public AudioSource ShootSounds;



    void Start()
    {
        gamemanager = GameObject.FindWithTag("GameManager");
        AttackTimeCount = AttackTime;

        

    }

    
    void Update()
    {
      
  

        
        if (triggerstay == false)//lazer silah�n�n line � i�in
        {
            if (islaser)
            {
                if (Linerenderer.enabled)
                {
                    Linerenderer.enabled = false;
                }
                laserhit = 0;
            }
            
            return;
        }



        if (isTurret == true)
        {
            if (Parent.GetComponent<Dragger>().Isbuilded == true) // e�er real build olduysa
            {
                if (triggerstay == true)//turret�n i�ine d��man girince �al���r
                {
                    FindClosestEnemy();//en yak�n dusman� bulur
                    Detected = true;
                    if (!islaser)
                    {
                        AttackTimeCount -= Time.deltaTime;// sald�r� s�resini azalt�r
                    }
                }

                if (Detected && BuildBlocked == false )//ate� etme
                {
                    if (islaser)
                    {
                        if (gamemanager.GetComponent<BuildSystem>().ElectricBalance > 0)
                        {

                            Laser();
                        }
                    }
                    else if (isMortar)
                    {
                        if (gamemanager.GetComponent<BuildSystem>().MortarBulletBalance > 0)
                        {
                            if (AttackTimeCount < 0f)
                            {

                                shoot();
                                AttackTimeCount = AttackTime;
                            }
                        }
                    }

                    else//mermili
                    {
                        if (gamemanager.GetComponent<BuildSystem>().BulletBalance > 0)
                        {
                            if (AttackTimeCount < 0f)
                            {

                                shoot();
                                AttackTimeCount = AttackTime;
                            }
                        }

                    }

                   
                }
            }
        }
        else
        {
            if (triggerstay == true)//turret�n i�ine d��man girince �al���r
            {
               
                FindClosestEnemy();//en yak�n dusman� bulur
                Detected = true;
                AttackTimeCount -= Time.deltaTime;// sald�r� s�resini azalt�r
            }
                
          

            if (Detected  && BuildBlocked == false && gamemanager.GetComponent<BuildSystem>().BulletBalance > 0)//ate� etme
            {

               
                    if (AttackTimeCount < 0f)
                    {

                        shoot();
 
                        AttackTimeCount = AttackTime;
                    }
                
                
            }
        }

       

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")//alana d��man girince
        {
            
            Enemycounter += 1;
            triggerstay = true;
            

            


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")//d��man alandan ��k�nca
        {
            
            if (triggerstay == true)
            {
                Enemycounter -= 1;
            }
           
            if (Enemycounter <=0)
            {
                triggerstay = false;
            }
            
            Detected = false;


        }
    }

    void FindClosestEnemy() // en yak�n hedefi bulur
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
        targetPos = ClosestEnemy.gameObject;
        
            targetPos.transform.position = ClosestEnemy.transform.position;
            Direction = (Vector2)targetPos.transform.position- (Vector2)transform.position;


        
         
        

        Gun.transform.up = Direction; // silah d��mana d�ner
        
    }

    void shoot() //ate� etme
    {

        if (shoot1 == true && shoot2 == false)
        {
            

            ShootSounds.Play();
             BulletIns = Lean.Pool.LeanPool.Spawn(bullet, Shootpoint.position, Quaternion.identity);
             BulletIns.GetComponent<Rigidbody2D>().velocity = Direction.normalized * Force;
               
            BulletIns.transform.up = Direction;

            //BulletIns.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(Direction.normalized, Direction.normalized,Force* Time.deltaTime);
            if (isMortar)
            {
                gamemanager.GetComponent<BuildSystem>().MortarBulletBalance -= 1;

            }
            else
            {
                gamemanager.GetComponent<BuildSystem>().BulletBalance -= 1;
            }
            
            Lean.Pool.LeanPool.Despawn(BulletIns, 1.5f);
            shoot1 = false;
            shoot2 = true;
        }
        else if (shoot2 == true && shoot1 == false)
        {
           

            ShootSounds.Play();
            BulletIns = Lean.Pool.LeanPool.Spawn(bullet, Shootpoint1.position, Quaternion.identity);
            
            BulletIns.GetComponent<Rigidbody2D>().velocity = Direction.normalized * Force;
            
            BulletIns.transform.up = Direction;

            //BulletIns.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(Direction.normalized, Direction.normalized, Force*Time.deltaTime);

            gamemanager.GetComponent<BuildSystem>().BulletBalance -= 1;
            Lean.Pool.LeanPool.Despawn(BulletIns, 1.5f);
            shoot1 = true;
            shoot2 = false;
        }




    }

    void Laser()
    {
      
        if (!Linerenderer.enabled)
        {
            Linerenderer.enabled = true;
            
        }

        Linerenderer.SetPosition(0, Shootpoint.position);
        Linerenderer.SetPosition(1, targetPos.transform.position);
        
        lasershoottimer -= Time.deltaTime;
        if (lasershoottimer <0)
        {
            if (isUraniumLaser)
            {
                targetPos.GetComponent<Health>().health -= 1 + laserhit;
                gamemanager.GetComponent<BuildSystem>().ElectricBalance -= 6;

                if (laserhit < 10)
                {
                    laserhit += .25f;



                }
                lasershoottimer = 0.1f;
            }
            else
            {
                targetPos.GetComponent<Health>().health -= 1 + laserhit;
                gamemanager.GetComponent<BuildSystem>().ElectricBalance -= 4;

                if (laserhit < 4)
                {
                    laserhit += .1f;



                }
                lasershoottimer = 0.1f;
            }
            
            
        }

    }

}
