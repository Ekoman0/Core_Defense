using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    
    public bool Is30px;
    public float grid = 0.3f;
    float x = 0f, y = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Is30px == false)
        {
            if (grid > 0)
            {
                float reciprocalgrid = 1f / grid;
                x = Mathf.Round(transform.position.x * reciprocalgrid) / reciprocalgrid;
                y = Mathf.Round(transform.position.y * reciprocalgrid) / reciprocalgrid;
                transform.position = new Vector3(x, y, transform.position.z);
            }
        }
        else
        {
           
            
                if (grid > 0)
                {
                    float reciprocalgrid = 1f / grid;
                    x = Mathf.Round(transform.position.x * reciprocalgrid) / reciprocalgrid + 0.15f;
                    y = Mathf.Round(transform.position.y * reciprocalgrid) / reciprocalgrid - 0.15f;
                    transform.position = new Vector3(x, y, transform.position.z);
                }
            
            
        }
        
    }
}
