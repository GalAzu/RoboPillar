using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WasteInventory 

{
    public WasteData wasteData;
    public int stackSize;
    public WasteInventory(WasteData _waste)
    {
        wasteData = _waste;
        AddToStack();
    }
    public void AddToStack()
    {
        stackSize++;
    }
    public void RemoveFromStack()
    {
        stackSize--;
    }
}
