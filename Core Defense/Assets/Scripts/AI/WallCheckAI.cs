using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckAI : MonoBehaviour
{
    private int WallCount=0; //ontriggera giren duvarlar� sayar.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Wall")
        {
            WallCount += 1;
        }
    }
}
