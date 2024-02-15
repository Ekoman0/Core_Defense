using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
public class DataManager : MonoBehaviour
{
public static DataManager Instance{ get; set; }
    public ItemDB ItemDB;
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItem(GameObject obj)
    {
        Item item = new Item();

        item.Position = obj.transform.position;
        ItemDB.items.Add(item);
    }
    public void RemoveItem(Vector3 obj)
    {
        Item ýtem = ItemDB.items.Where(p => p.Position == obj).First();
        ItemDB.items.Remove(ýtem);
    }
    public void savedata()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ItemDB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamFiles/Game_data.xml", FileMode.Create);
        xmlSerializer.Serialize(stream, ItemDB);
        stream.Close();
    }
    public void Loaddata()
    {
        if (!File.Exists(Application.dataPath + "/StreamFiles/Game_data.xml")) return;
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ItemDB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamFiles/Game_data.xml", FileMode.Open);
        ItemDB = xmlSerializer.Deserialize(stream) as ItemDB;
        stream.Close();
    }

 
}

[System.Serializable]
public class ItemDB
{
    public List<Item> items = new List<Item>();
}

public class Item
{
    public string PrefabID;
    public string ItemID;
    public Vector3 Position;
}