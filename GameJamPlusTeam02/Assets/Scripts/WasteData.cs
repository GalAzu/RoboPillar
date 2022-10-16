using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Waste", menuName = "ScriptableObjects/WasteObjects", order = 1)]

public class WasteData : ScriptableObject
{
    public string name;
    public enum wasteType { Bolts , MetalSheet , TowerComponents }
    public wasteType _wasteType;
    public float effectOnWorld;
    public int quantityToAdd ;
}
