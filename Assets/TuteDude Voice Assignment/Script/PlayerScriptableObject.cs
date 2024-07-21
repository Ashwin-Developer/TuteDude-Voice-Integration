using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player",menuName ="ScriptableObject/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    public List<GameObject> player = new List<GameObject>();
} 
