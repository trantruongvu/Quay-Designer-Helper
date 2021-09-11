using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public string ProfileInfo;
    public Sprite Default;
    public Sprite Avatar;
    public Sprite Sprite;
    public int ValueControl;
    public int ValueExecution;
    public int ValueThinking;
    public int ValueResilient;
}
