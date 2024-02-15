using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Info",menuName ="Info Card")]
public class InfoScriptableObject : ScriptableObject
{
    public bool iselectricy;
    public string ObjectName;
    public Sprite ObjectIcon;
    public Sprite ElectricIcon;

}
