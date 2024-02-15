using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorDetector : MonoBehaviour
{
    
    public GameObject parent;

    public List<GameObject> minedore;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        Debug.Log(minedore.Count);
        if (minedore.Count > 0)
        {
            parent.GetComponent<Conveyor>().canmove =false;
        }
        else if (minedore.Count == 0)
        {
            parent.GetComponent<Conveyor>().canmove = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="qq")
        {
            minedore.Add(collision.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="qq")
        {
            minedore.Remove(collision.gameObject);

        }
    }
}
