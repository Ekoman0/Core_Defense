using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PrefabDataBase : MonoBehaviour
{
    public static PrefabDataBase Instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
    public List<PrefabItem> PrefabsItems = new List<PrefabItem>();
        
    public GameObject RequestPrefab(string Prefab_ID)
    {
        PrefabItem prefabItem = PrefabsItems.Where(p => p.Prefab_ID == Prefab_ID).First();
        return prefabItem.Prefab_Gameobject;
    }
}   



[System.Serializable]
public class PrefabItem
{
    public GameObject Prefab_Gameobject;
    public string Prefab_ID;
}
