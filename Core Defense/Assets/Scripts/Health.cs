using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    private GameObject player;
    private GameObject core;
    public bool IsPlayer;
    public bool IsHaventDragger;
    public bool enemy=false;
    public bool build= false;
    public float health;
    public float initHealth;
    public Image healthBar;
    public Image healthBarBlack;
    public ParticleSystem explosiveeffect;
    float plyrtimer = 7f;
    


    // Start is called before the first frame update
    void Start()
    {
        if (IsPlayer)
        {
            core = GameObject.Find("CORE");
            player = GameObject.Find("Player");
        }
        initHealth = health; 
    }

    // Update is called once per frame
    void Update()
    {
        if (health == initHealth)
        {
            healthBar.gameObject.SetActive(false);
            healthBarBlack.gameObject.SetActive(false);

        }
        else
        {
            healthBar.gameObject.SetActive(true);
            healthBarBlack.gameObject.SetActive(true);

        }



        if (health > initHealth)
        {
            health = initHealth;
        }

        healthBar.fillAmount = (float)health / (float)initHealth;
        
        if (health <= 0)
        {

            if (build)
            {
                Instantiate(explosiveeffect, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else
            {
                if (!IsPlayer)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                   
                    MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
                    
                    foreach (MonoBehaviour c in comps)
                    {
                        c.enabled = false;
                    }
                    GetComponent<Health>().enabled = true;
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<BoxCollider2D>().enabled = false;
                    gameObject.transform.Find("AttackRange").GetComponent<Attack>().enabled = false;
                    //player.SetActive(false);
                }
            }
            if (IsPlayer)
            {
                plyrtimer -= Time.deltaTime;
                if (plyrtimer< 0)
                {
                    player.GetComponent<Health>().health = initHealth;
                    MonoBehaviour[] comps = GetComponents<MonoBehaviour>();

                    foreach (MonoBehaviour c in comps)
                    {
                        c.enabled = true;
                    }
                    GetComponent<Health>().enabled = true;
                    player.transform.position = core.transform.position;
                    GetComponent<SpriteRenderer>().enabled = true;
                    GetComponent<BoxCollider2D>().enabled = true;
                    gameObject.transform.Find("AttackRange").GetComponent<Attack>().enabled = true;

                    //player.SetActive(true);
                    plyrtimer = 7f;
                }
            }
            

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
         if(enemy == false)
         {
            if (IsHaventDragger == false)
            {
                if (gameObject.GetComponent<Dragger>().Isbuilded == true)//real build olunca
                {
                    if (collision.gameObject.tag == "EnemyBullet")
                    {
                        health -= 10;
                        Lean.Pool.LeanPool.Despawn(collision.gameObject);

                    }
                    if (collision.gameObject.tag == "EnemyBullet2")
                    {
                        health -= 17;
                        Lean.Pool.LeanPool.Despawn(collision.gameObject);

                    }
                    if (collision.gameObject.tag == "EnemySniperBullet")
                    {
                        health -= 70;
                        Lean.Pool.LeanPool.Despawn(collision.gameObject);

                    }
                    if (collision.gameObject.tag == "EnemyMinigunBullet")
                    {
                        health -= 10;
                        Lean.Pool.LeanPool.Despawn(collision.gameObject);

                    }
                    if (collision.gameObject.tag == "EnemyBossBullet")
                    {
                        collision.gameObject.GetComponentInChildren<Bomberman>().bombermantriggerenter = true;


                    }
                }
            }
            else
            {
                if (collision.gameObject.tag == "EnemyBullet")
                {
                    health -= 10;
                    Lean.Pool.LeanPool.Despawn(collision.gameObject);

                }
                if (collision.gameObject.tag == "EnemyBullet2")
                {
                    health -= 17;
                    Lean.Pool.LeanPool.Despawn(collision.gameObject);

                }
                if (collision.gameObject.tag == "EnemySniperBullet")
                {
                    health -= 70;
                    Lean.Pool.LeanPool.Despawn(collision.gameObject);

                }
                if (collision.gameObject.tag == "EnemyMinigunBullet")
                {
                    health -= 10;
                    Lean.Pool.LeanPool.Despawn(collision.gameObject);

                }
                if (collision.gameObject.tag == "EnemyBossBullet")
                {
                    collision.gameObject.GetComponentInChildren<Bomberman>().bombermantriggerenter=true;
                    

                }
            }
             
         }

        
        if (enemy)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                
                health -= 10;
                Lean.Pool.LeanPool.Despawn(collision.gameObject);
            }
            if (collision.gameObject.tag == "AdvancedUraniumBullet")
            {

                health -= 20;
                Lean.Pool.LeanPool.Despawn(collision.gameObject);
            }
            if (collision.gameObject.tag == "PlayerBullet")
            {
                if (PlayerPrefs.HasKey("PlayerDamage"))
                {
                    
                    int dmg;
                    dmg = PlayerPrefs.GetInt("PlayerDamage");
                    health -= dmg;
                    Lean.Pool.LeanPool.Despawn(collision.gameObject);
                }
                else
                {
                    
                    health -= 10;
                    Lean.Pool.LeanPool.Despawn(collision.gameObject);
                }
                
            }
            if (collision.gameObject.tag == "MortarBullet")
            {
                
                collision.gameObject.GetComponentInChildren<MortarBullet>().bombermantriggerenter = true;
            }
        }
        
        
        
        
    }
}
