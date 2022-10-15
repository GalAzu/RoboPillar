using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Waste", menuName = "ScriptableObjects/WasteObjects", order = 1)]

public class WasteData : ScriptableObject
{
    public enum wasteType {bolts , metals , scrapes }
    public wasteType _wasteType;
    public float effectOnWorld;
    public int placeInInventory;
    public Sprite icon;
}
