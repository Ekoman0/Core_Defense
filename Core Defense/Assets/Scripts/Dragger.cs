using UnityEngine;
using SaveLoadSystem;
public class Dragger : MonoBehaviour,ISaveable
{
    public bool Is30px;
    public float grid = 0.3f;
    float x = 0f, y = 0f;



    [SerializeField]public bool Isbuilded = false;
    
    public bool IsNotTurretButHaveRange;
   
    public bool IsTurret;
    private bool triggerstay = false;
    public GameObject range;
    public GameObject Gun;
    private bool dragingnoattack;
    public bool BuildBlocked = false;
    private bool BuildBlockedNoGunObject = false;
    public bool blocked = false;
    private Vector3 oldPosition;
    private Vector3 _dragOffset;
    public  bool draging=false;
    private Camera _cam;
    public int sayac = 0;

    [SerializeField] private float _speed = 10;


    [System.Serializable]
    struct DraggerData
    {
        public bool Isbuilded;
    }

    void Awake()
    {
        
        _cam = Camera.main;
    }
    private void Start()
    {
        if (IsTurret || IsNotTurretButHaveRange)
        {           
            range.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }
    private void Update()
    {

     
       

        if (triggerstay == true)
        {
            
            BuildBlocked = true;
        }

        if (IsNotTurretButHaveRange == true)
        {
            //obje real build olmadýysa range i görünür yap
            if (Isbuilded == false)
            {
                range.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                range.GetComponent<SpriteRenderer>().enabled = false;
            }                 
          
        }
        


        if (IsTurret == true)
        {
            if (Isbuilded==false)
            {
                range.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                range.GetComponent<SpriteRenderer>().enabled = false;
            }
           
      
        }
        
        
    }
    void OnMouseDown()
    {
        if (BuildSystem.Moveitem == true)
        {
            if (Isbuilded == false)
            {
                oldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                _dragOffset = transform.position - GetMousePos();
                draging = true;
                CameraMove.move = false;
            }
            
        }
        
    }

    void OnMouseDrag()
    {


        if (Isbuilded == false)
        {
            if (BuildSystem.Moveitem == true)
            {
                if (Is30px)
                {
                    float reciprocalgrid = 1f / grid;


                    transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
                    x = Mathf.Round(transform.position.x * reciprocalgrid) / reciprocalgrid + 0.15f;
                    y = Mathf.Round(transform.position.y * reciprocalgrid) / reciprocalgrid - 0.15f;
                    transform.position = new Vector3(x, y, transform.position.z);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
                }
                
            }
        }
        

        //transform.position =new Vector3()
    }
    
    private void OnMouseUp()
    {
        
        
        
        if (BuildSystem.Moveitem == true)
        {
            if (Isbuilded == false)
            {
                if (blocked == true)
                {
                    transform.position = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z);
                    blocked = false;
                }

                draging = false;
                CameraMove.move = true;
            }
            
        }
            
    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Copper" || collision.gameObject.tag == "Iron" || collision.gameObject.tag == "Coal" || collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "Factory" || collision.gameObject.tag == "BigHealthRegen" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "Uranium" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall" || collision.gameObject.tag == "UraniumDrill")
        {

            sayac++;
            blocked = true;
            BuildBlockedNoGunObject = true;
            triggerstay = true;
            
        }
       
        

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Copper" || collision.gameObject.tag == "Iron" || collision.gameObject.tag == "Coal" || collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "Turret1" || collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "Core" || collision.gameObject.tag == "RegenHealthMachine" || collision.gameObject.tag == "CoalToElectric" || collision.gameObject.tag == "IronWall" || collision.gameObject.tag == "Factory" || collision.gameObject.tag == "BigHealthRegen" || collision.gameObject.tag == "ElectricTurret" || collision.gameObject.tag == "AdvancedTurret" || collision.gameObject.tag == "LaserTurret" || collision.gameObject.tag == "MortarTurret" || collision.gameObject.tag == "AdvancedUraniumTurret" || collision.gameObject.tag == "Uranium" || collision.gameObject.tag == "MortarUraniumTurret" || collision.gameObject.tag == "LaserUraniumTurret" || collision.gameObject.tag == "SteelWall" || collision.gameObject.tag == "UraniumWall" || collision.gameObject.tag == "UraniumDrill")
        {
            sayac--;
            if (sayac<=0)
            {
               
                blocked = false;
                BuildBlockedNoGunObject = false;
                BuildBlocked = false;
                triggerstay = false;
            }
           
        }
        if (Isbuilded == false)
        {
            if (collision.gameObject.tag == "Floor")
            {
                blocked = true;
            }
        }
        
    }

    public bool NeedsToBeSaved()
    {
        return true;
    }

    public bool NeedsReinstantiation()
    {
        return true;
    }

    public object SaveState()
    {
        return new DraggerData()
        {
            Isbuilded = Isbuilded
        };
    }

    public void LoadState(object state)
    {
        DraggerData data = (DraggerData)state;

        this.Isbuilded = data.Isbuilded;
    }

    public void PostInstantiation(object state)
    {
        DraggerData data = (DraggerData)state;
    }

    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {
        throw new System.NotImplementedException();
    }
}