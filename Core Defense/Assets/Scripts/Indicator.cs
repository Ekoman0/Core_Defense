using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject indicator;
    private GameObject Target;
    private Renderer rb;
    void Start()
    {
        Target = GameObject.FindWithTag("Player");
        rb = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.isVisible == false)
        {
            if (!indicator.activeSelf == false)
            {

                indicator.SetActive(true);
            }

            Vector2 direction = Target.transform.position - transform.position;
            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);
            if (ray.collider != null)
            {

                indicator.transform.position = ray.point;
            }
        }
        else
        {
            if (indicator.activeSelf == false)
            {

                indicator.SetActive(false);
            }
        }
    }
}