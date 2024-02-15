using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    Rigidbody2D  rb;
     public List<Transform> Conveyors;
    Vector3 Direction;
    public float speed = 2.0f;
    public bool canmove = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {
        if (Conveyors != null && canmove == true)
        {
            Direction = Conveyors[0].transform.position - transform.position;
            moveCharacter(Direction);
            this.transform.up = Direction;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Conveyor")
        {
            Conveyors.Add(collision.gameObject.transform.GetChild(0));
        }
        if (collision.gameObject.tag == "ConveyorBridge1Up")
        {

        }
        if (collision.gameObject.tag == "ConveyorBridge1Down")
        {

        }
        if (collision.gameObject.tag == "ConveyorBridge2Left")
        {

        }
        if (collision.gameObject.tag == "ConveyorBridge2Right")
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Conveyor")
        {
            Conveyors.Remove(collision.gameObject.transform.GetChild(0));
        }
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * speed * Time.deltaTime));
    }








}
