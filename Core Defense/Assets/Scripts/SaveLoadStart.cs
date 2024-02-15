using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveLoadStart : MonoBehaviour
{

    // Start is called before the first frame update
    private void Awake()
    {
        SaveLoadSystem.SaveLoadSystem.Load();
    }
    


}
