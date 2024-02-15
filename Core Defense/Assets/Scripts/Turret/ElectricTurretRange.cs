using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTurretRange : MonoBehaviour
{
    private int Enemycounter = 0; //turret�n alan�ndaki d��manlar� sayar
    private bool triggerstay = false; //turret�n ontriggerstay fonksiyonunu halleder(performans i�in ontriggerstay kullanm�yorum)
    public GameObject Gun; //turret
    public GameObject Parent;//turret�n babas�
    Vector2 Direction;// turret� d��mana d�nd�rmek i�in
    bool Detected = false; // d��man� detect etmek i�in
    private GameObject gamemanager;
    public float AttackTime;// ate� etme zaman�
    private float AttackTimeCount;//�sttekine fix
    public ParticleSystem ps;
    public GameObject AttackHit;
    public Animator animator;

    public AudioSource ShootSounds;
    void Start()
    {
        gamemanager = GameObject.FindWithTag("GameManager");
        AttackTimeCount = AttackTime;
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Parent.GetComponent<Dragger>().Isbuilded == true) // e�er real build olduysa
        {
            if (triggerstay == true)//turret�n i�ine d��man girince �al���r
            {
                FindClosestEnemy();//en yak�n dusman� bulur
                Detected = true;
            }

            if (Detected == true)
            {
                
                if (gamemanager.GetComponent<BuildSystem>().ElectricBalance > 20)
                {
                    animator.SetBool("Shoot", true);
                    AttackTimeCount -= Time.deltaTime;
                    
                    if (AttackTimeCount < 0f)
                    {

                        shoot();
                        AttackTimeCount = AttackTime;
                    }
                }
               
            }
            else
            {
                animator.SetBool("Shoot", false);
            }
            if (ps.isStopped == true)
            {
                AttackHit.GetComponent<BoxCollider2D>().enabled = false;
               
            }
        }
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")//alana d��man girince
        {
            Debug.Log("entertrig");
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

            if (Enemycounter <= 0)
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
        Vector2 targetPos = ClosestEnemy.transform.position;
        Direction = targetPos - (Vector2)transform.position;
        Gun.transform.up = Direction; // silah d��mana d�ner 

    }
    void shoot()
    {
        ShootSounds.Play();
        Debug.Log("shot");
        ps.Play();
        AttackHit.GetComponent<BoxCollider2D>().enabled = true;
        animator.SetBool("Shoot", false);
    }
}
