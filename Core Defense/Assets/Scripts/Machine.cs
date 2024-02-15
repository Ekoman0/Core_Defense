
using UnityEngine;


public class Machine : MonoBehaviour
{

    [Header("Page")]
    public GameObject FactoryCanvasImage;
    public GameObject LimitationCanvasImage;

    
    void Start()
    {
        
        FactoryCanvasImage.gameObject.SetActive(false);
        LimitationCanvasImage.gameObject.SetActive(false);
    
    }

    // Update is called once per frame
    
    
}
