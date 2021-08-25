using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Avatar;
    public Sprite Sprite;
    public int ValueOrganised;
    public int ValueKnowledge;
    public int ValueCreative;
    public int ValueResilient;
}
