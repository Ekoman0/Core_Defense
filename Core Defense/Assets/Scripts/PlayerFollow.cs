using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    
    public Transform target;
    





    private Rigidbody2D rb;
    
    public float moveSpeed = 5f;
    private Vector2 movement;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
      
       // Vector3 mousePosition = Input.mousePosition;
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

       

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle -90;
        direction.Normalize();
        movement = direction;


    }
  
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
